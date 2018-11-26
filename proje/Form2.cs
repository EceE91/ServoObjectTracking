using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;

namespace proje
{
    public partial class Form2 : Form
    {
        // member variables
        Capture capWebcam = null;
        bool blnCapturingInProcess = false;
        Image<Bgr, Byte> imgOriginal;
        Image<Gray, Byte> imgProcessed;
 

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                capWebcam = new Capture(); // associate capture object to the default webcam


            }
            catch(NullReferenceException exception) {
                MessageBox.Show("Cannot Run Webcam \nException: " + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtXYRadius.Text = exception.Message;
                return;
            }

            // because of the events, we do not need threads
            Application.Idle += processFrameAndUpdateGUI; // add process image function to the application's list of tasks 
            blnCapturingInProcess = true;
        }

        void processFrameAndUpdateGUI(object sender, EventArgs args) {
            imgOriginal = capWebcam.QueryFrame(); // get the next frame from webcam
            if (imgOriginal == null) return; // if we dont get frame, bail
          
            imgProcessed = imgOriginal.InRange(new Bgr(0, 0, 175), // min filter value (if color is greater than or equal to this)
                                               new Bgr(100, 100, 256)); // max filter value (if color is less than or equal to this)
            imgProcessed=imgProcessed.Convert<Gray, Byte>().PyrDown().PyrUp();
            imgProcessed = imgProcessed.SmoothGaussian(9); // we call smoothGaussion function with only one param,that being the x and y size of the filter window
            


            // The Canny edge detector is an edge detection operator that uses a multi-stage algorithm to detect a wide range of edges in images
            // houghCircle info at http://www.cse.iitd.ac.in/~parag/projects/DIP/asign2/houghcirc.shtml
            CircleF[] circles = imgProcessed.HoughCircles(new Gray(100), // canny treshold
                                                          new Gray(50),  // accumulator treshold (detect the circles)
                                                          2,             // size of image / thi param= "accumulator resolution"
                                                          imgProcessed.Height / 4, // min distance in pixels between the centers of detected circles
                                                          10,            // min radius of detected circles
                                                          400            // max radius of detected circles
                                                          )[0];          // [0] => get circles from the first channel
            foreach (CircleF circle in circles)
            {
                if (txtXYRadius.Text != "") txtXYRadius.AppendText(Environment.NewLine); // if we are not on the first line in the text box, insert a niew line
                txtXYRadius.AppendText("Object Position -x "+ circle.Center.X.ToString().PadLeft(4) // x position of center point of circle
                                                            + ", -y= " + circle.Center.Y.ToString().PadLeft(4) // y position of center point of circle
                                                            + ", radius "+ circle.Radius.ToString("###.000").PadLeft(7)); // 3 point precision
                txtXYRadius.ScrollToCaret(); // move the text box scroll bar down to line we just wrote 

                                // draw a small green circle at the center of the detected object
                                // to do this, we will call the openCv 1.x function this is necessary because
                                // we are drawing a circle of radius 3. even though the size of the detected circle will be much bigger
                                // the CvInvoke object can be used to make OpenCv 1.x function calls
                CvInvoke.cvCircle(imgOriginal,                                          // draw on the original image
                                  new Point((int)circle.Center.X,(int)circle.Center.Y), // center point of circle
                                  3,                                                    // radius of circle in pixels
                                  new MCvScalar(0,255,0),                               // draw pure green
                                  -1,                                       // thickness of the circle, -1 indicates to fill the circle
                                  LINE_TYPE.CV_AA,                                       // use AA to smooth the pixells
                                  0);                                                    // no shift 

                                // draw a red circle around the detected object
                imgOriginal.Draw(circle,             // current circle we are on in foreach loop
                                 new Bgr(Color.Red), // draw pure red
                                 3);                 // thickness of circle of pixells
                  
            } // end foreach
            IbOriginal.Image = imgOriginal;
            IbProcessed.Image = imgProcessed;

        }

        private void btnPauseOrResume_Click(object sender, EventArgs e)
        {
            if (blnCapturingInProcess == true)   // we are currently processing an image, user just choose pause
            {              
                Application.Idle -= processFrameAndUpdateGUI; // remove the process image function from the applications list of tasks
                blnCapturingInProcess = false;
                btnPauseOrResume.Text = "Play";
            }
            else {  // app is not running
                Application.Idle += processFrameAndUpdateGUI; // add process image function to the application's list of tasks 
                blnCapturingInProcess = true;
                btnPauseOrResume.Text = "Pause";
            }

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            // This function is not necessary
            if (capWebcam != null) {
                capWebcam.Dispose();
            }
        }


    }
}
