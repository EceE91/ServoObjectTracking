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
using Emgu.CV.UI;
using Emgu.CV.VideoSurveillance;
using Emgu.CV.Structure;
using Emgu.Util;

namespace proje
{
    public partial class DenemeForm : Form
    {
        public DenemeForm()
        {
            InitializeComponent();
        }

 
        private Capture _capture;
        private bool _captureInProgress;
        Image<Gray, Byte> draw; //This is the image which draws your LEDs' movements
        bool first = true;
        
      
        private void ProcessFrame(object sender, EventArgs arg)
        {
            Image<Gray, Byte> frame1 = _capture.QueryGrayFrame().ThresholdBinary(new Gray(254), new Gray(255));
            
            //find Canny edges 
            Image<Gray, Byte> canny = frame1.Canny(new Gray(255), new Gray(255));
            
            // If drawing for the first time, initialize "diff", else draw on it
                if (first)
                {
                    draw = new Image<Gray, Byte>(frame1.Width, frame1.Height, new Gray(0));
                    //If you take you LED into this rectangle (at the bottom left corner), 
                    //then the screen will refresh and all your markings will be cleared
                    draw.Draw(new Rectangle(0, 455, 25, 25), new Gray(255), 0);
                    first = !first;
                }
                else
                {
                    //In this loop, we find contours of the canny image and using the
                    //Bounding Rectangles, we find the location of the LED(s)
                    for (Contour<System.Drawing.Point> contours = canny.FindContours(
                              Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE,
                              Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_EXTERNAL); contours != null; contours = contours.HNext)
                    {
                        //Check if LED(s) point lies in the region of refreshing the screen
                        if (contours.BoundingRectangle.X <= 25 && contours.BoundingRectangle.Y >= 455)
                        {
                            first = true;
                            break;
                        }
                        else
                        {
                            Point pt = new Point(contours.BoundingRectangle.X, contours.BoundingRectangle.Y);
                            draw.Draw(new CircleF(pt, 5), new Gray(255), 0);
                            canny.Draw(contours.BoundingRectangle, new Gray(255), 1);
                        }
                    }

                 }
               
            captureImageBox.Image = canny;
            grayscaleImageBox.Image = draw;
            
        }



        private void captureButton_Click(object sender, EventArgs e)
        {
            #region 
            if (_capture == null)
            {
                try
                {
                    _capture = new Capture();
                }
                catch (NullReferenceException excpt)
                {
                    MessageBox.Show(excpt.Message);
                }
                
            }
            #endregion

            if (_capture != null)
            {
                if (_captureInProgress)
                {  //stop the capture
                    captureButton.Text = "Start Capture";
                    first = false;
                    Application.Idle -= ProcessFrame;
                }
                else
                {
                    //start the capture
                    captureButton.Text = "Stop";
                    Application.Idle += ProcessFrame;
                }

                _captureInProgress = !_captureInProgress;
            }
        }

        private void ReleaseData()
        {
            if (_capture != null)
                _capture.Dispose();
        }

       }
}


