using System;
using System.Drawing;  // For Bitmap
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing.SkiaSharp;  // ZXing.SkiaSharp for QR code decoding
using SkiaSharp;  // SkiaSharp for bitmap handling

namespace brgy_system
{
    public partial class ScanQR : Form
    {
        private FilterInfoCollection videoDevices;  // Store available video devices (webcams)
        private VideoCaptureDevice videoCaptureDevice;  // The video capture device (webcam)
        private BarcodeReader barcodeReader;  // ZXing.SkiaSharp barcode reader for decoding QR codes

        // Define delegate for event
        public delegate void QRDataExtractedEventHandler(string fullName, string age, string dob, string gender, string civilStatus, string religion, string placeOfBirth, string address);

        // Declare the event
        public event QRDataExtractedEventHandler QRDataExtracted;

        public ScanQR()
        {
            InitializeComponent();
            barcodeReader = new BarcodeReader();  // Initialize ZXing.SkiaSharp BarcodeReader
            this.Load += ScanQR_Load;  // When the form loads
        }

        // This event is triggered when the form is loaded
        private void ScanQR_Load(object sender, EventArgs e)
        {
            // Get video devices (webcams)
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count == 0)
            {
                MessageBox.Show("No video devices found.");
                return;
            }

            // Initialize the first video device (webcam)
            videoCaptureDevice = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;  // Capture new frames
            videoCaptureDevice.Start();  // Start the webcam immediately
        }

        // Event handler for each new frame from the webcam
        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Capture the latest frame from the webcam and display it
            Bitmap latestFrame = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = latestFrame; // Show live video feed in the PictureBox
        }

        // Stop the webcam when the form is closed
        private void ScanQR_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoCaptureDevice != null && videoCaptureDevice.IsRunning)
            {
                videoCaptureDevice.SignalToStop();
                videoCaptureDevice.WaitForStop();
            }
        }

        // Event handler for the "Scan QR" button
        private void btnScanQR_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.Image != null)
                {
                    // Capture the latest frame from PictureBox
                    Bitmap latestFrame = (Bitmap)pictureBox1.Image;

                    // Convert Bitmap to SKBitmap (SkiaSharp)
                    using (var skBitmap = BitmapToSKBitmap(latestFrame))
                    {
                        // Use ZXing.SkiaSharp to decode the QR code from the SKBitmap
                        var result = barcodeReader.Decode(skBitmap);
                        if (result != null)
                        {
                            // If the QR code is successfully decoded, extract the data
                            ExtractResidentData(result.Text);  // Use the QR content to extract data
                        }
                        else
                        {
                            // If no QR code is detected
                            MessageBox.Show("No QR Code detected.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No image available to scan.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error scanning QR code: " + ex.Message);
            }
        }

        // Convert Bitmap to SKBitmap (SkiaSharp)
        private SKBitmap BitmapToSKBitmap(Bitmap bitmap)
        {
            // Create a SKBitmap with the same width and height as the Bitmap
            using (var stream = new System.IO.MemoryStream())
            {
                // Save the Bitmap to a MemoryStream as PNG
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                stream.Seek(0, System.IO.SeekOrigin.Begin);

                // Create SKBitmap from the MemoryStream
                return SKBitmap.Decode(stream);
            }
        }

        // Extract data from the QR code and pass it back to the parent form
        private void ExtractResidentData(string qrData)
        {
            try
            {
                // Split the QR data by lines
                var residentData = qrData.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                // Ensure there are at least 8 lines (fields) in the QR data
                if (residentData.Length >= 8)
                {
                    // Extract and assign the values from the QR code
                    string fullName = GetFieldValue(residentData, "Name");
                    string age = GetFieldValue(residentData, "Age");
                    string dob = GetFieldValue(residentData, "Date Of Birth");
                    string gender = GetFieldValue(residentData, "Gender");
                    string civilStatus = GetFieldValue(residentData, "Civil Status");
                    string religion = GetFieldValue(residentData, "Religion");
                    string placeOfBirth = GetFieldValue(residentData, "Place of Birth");
                    string address = GetFieldValue(residentData, "Address");

                    // Trigger the event to send the extracted data back to the parent form
                    QRDataExtracted?.Invoke(fullName, age, dob, gender, civilStatus, religion, placeOfBirth, address);
                    this.Close();  // Close the ScanQR form after passing the data
                }
                else
                {
                    MessageBox.Show("QR code data is in an incorrect format.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading QR code: " + ex.Message);
            }
        }

        // Helper function to extract a field value from the QR code data
        private string GetFieldValue(string[] data, string fieldName)
        {
            // Search for the specific field in the array
            foreach (var item in data)
            {
                if (item.StartsWith(fieldName))  // Check if the field starts with the specified name
                {
                    // If found, return the value after the colon
                    return item.Split(':')[1].Trim();  // Get the data after the colon
                }
            }
            return "";  // Return empty if the field is not found
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
