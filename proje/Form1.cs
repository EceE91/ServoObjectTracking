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
using Emgu.CV.Features2D;
using Emgu.CV.Util;


namespace proje
{
   
    public partial class Form1 : Form
    {
        Capture capturecam = null; // instance for capturing webcam
        bool capturingProcess = false; // capturing process status
        ClassFeatureTrack featureTrack = new ClassFeatureTrack();
     
        //Drawing
        int templateWidth = 20;
        int templateHeight = 20;

        Rectangle Image_ROI_Location;
        Rectangle Template_Location;

        //Object Change
        int NO_Match = 0;
        bool Start = false;

        // images 
        Image<Bgr, Byte> frame; // image type RGB (in OpenCV Bgr). The original color
        Image<Gray, Byte> template; // processed image will be grayscale so a gray image (the patch image)
        Image<Gray, Byte> GrayFrame;

        public Form1()
        {
            InitializeComponent();
      
        }


        public void startRecording() {
            CheckForIllegalCrossThreadCalls = false;

            try
            {
                capturecam = new Capture(0);
                Application.Idle += new EventHandler(Application_Idle);
                capturingProcess = true;
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Cannot Run Webcam \nException: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            startRecording();  
        }

   
        void Application_Idle(object sender, EventArgs e)
        {
            // For reducing the noises from picture use PyrUp() function (e.g capturecam.QueryFrame().PyrUp();)
            // This method incrases the number of pixells, which enables the images to be kept into and processed 
            // faster by computers
            frame = capturecam.QueryFrame();
            if (frame == null) return;

            // Bgr(50, 50, 50) represents the color gray and Bgr(255,255,255) represents the color white
            template = frame.InRange(new Bgr(50, 50, 50), new Bgr(255, 255, 255));
            // "SmoothGaussian" applies the Gaussian smoothing with the x,y length = 9
            template = template.SmoothGaussian(9);
            ımageBox1.Image = frame;
            ımageBox2.Image = template;

            GrayFrame = frame.Convert<Gray, Byte>();
            // For Rotating the image:
            // ımageBox2.Image =frame.Rotate(180, new Bgr(Color.Black));

            //Apply template to ROI 
            if (checkrange(Image_ROI_Location.X, Image_ROI_Location.Y))
            {
                if (featureTrack.TrackObject(GrayFrame.Copy(Image_ROI_Location), template))
                {
                    //Apply Ajustmet and display match location
                    Account_Movement();
                    DisplayImage();
                }
            }

                //if not found apply it to the whole image
            else if (featureTrack.TrackObject(GrayFrame.Copy(), template))
            {
                //Set New Location of Template and Template ROI
                Template_Location = new Rectangle(featureTrack.GetLocation().X, featureTrack.GetLocation().Y, templateWidth, templateHeight);
                Image_ROI_Location = new Rectangle(featureTrack.GetLocation().X - templateWidth / 2, featureTrack.GetLocation().Y - templateHeight / 2, templateWidth * 2, templateHeight * 2);
                DisplayImage();
            }
            else
            {
                //Track to see if object change
                int buffer = 50;
                if (Template_Location.X > buffer && Template_Location.X < frame.Width - buffer &&
                    Template_Location.Y > buffer && Template_Location.Y < frame.Height - buffer)
                {
                    NO_Match++;
                    if (NO_Match > 20)
                    {
                        NO_Match = 0;
                        //Create new template from last know location
                        SetTemplate(Template_Location.X, Template_Location.Y);
                        DisplayImage();
                    }
                }
                //Else just display Image
                else { 
                   // ımageBox3.Image = frame;
                    //ece = frame;
                    //Image<Bgr, Byte> copied = frame.Copy();
                    //copied.Draw(Image_ROI_Location, new Bgr(0, 0, 255), 1);
                    //ece = ece.ConcateHorizontal(copied);
                    //ımageBox1.Image = copied;
                }
            }

        }

        public void Account_Movement()
        {
            Image_ROI_Location.X += featureTrack.GetLocation().X - (templateWidth / 2);
            Image_ROI_Location.Y += featureTrack.GetLocation().Y - (templateHeight / 2);
            Template_Location.X += featureTrack.GetLocation().X - (templateWidth / 2);
            Template_Location.Y += featureTrack.GetLocation().Y - (templateHeight / 2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (capturingProcess == true)
            {
                // Application is not running/stopped
                Application.Idle -= Application_Idle;
                capturingProcess = false;
                button1.Text = "Play";

            }
            else
            {
                // Application is running
                Application.Idle += Application_Idle;
                capturingProcess = true;
                button1.Text = "Pause";

            }
        }

        private void ımageBox1_MouseDown(object sender, MouseEventArgs e)
        {
            
            if (capturecam != null) {
                     Image_ROI_Location = new Rectangle(e.X - 25, e.Y - 25, 50, 50);
                     frame.Draw(Image_ROI_Location, new Bgr(0, 255, 0), 1);
                    // frame.Draw(Template_Location, new Bgr(0, 255, 0), 1);
                     frame.ConcateHorizontal(frame);
                     ımageBox1.Image = frame;

                     SetTemplate(e.X, e.Y);
                 }
    
        }
        public Image<Bgr, Byte> ece = null;
        private void DisplayImage()
        {
            frame.Draw(Image_ROI_Location, new Bgr(0, 255, 0), 1);
          //  frame.Draw(Template_Location, new Bgr(0, 255, 0), 1);
            ımageBox1.Image = frame;

            //frame.Draw(Image_ROI_Location, new Bgr(0, 0, 255), 2);
            //frame.Draw(Template_Location, new Bgr(0, 255, 0), 2);
            //ımageBox2.Image = frame;
        }

        private void SetTemplate(int X, int Y)
        {
            if (checkrange(X, Y))
            {
                //Set template Location
                Template_Location = new Rectangle(X, Y, templateWidth, templateHeight);
                //check to make sure within Image Bounds
                template = GrayFrame.Copy(Template_Location);

                //Set ROI Location
                Image_ROI_Location = new Rectangle(X - templateWidth / 2, Y - templateHeight / 2, templateWidth * 2, templateHeight * 2);

                //Start Matching
                Start = true;
            }
        }

        public bool checkrange(int X, int Y)
        {
            if (X - templateWidth / 2 < 0) return false;
            if (Y - templateHeight / 2 < 0) return false;
            if (X + (templateWidth * 2) > frame.Width) return false;
            if (Y + (templateHeight * 2) > frame.Height) return false;
            return true;
        }

        private void ımageBox1_MouseClick(object sender, MouseEventArgs e)
        {
           
            Image_ROI_Location = new Rectangle(e.X - 25, e.Y - 25, 50, 50);
            frame.Draw(Image_ROI_Location, new Bgr(0, 255, 0), 1);
            //frame.Draw(Template_Location, new Bgr(0, 0, 255), 1);
            Image<Bgr, Byte> my = frame;
       
            my.ROI = new Rectangle(e.X - 25, e.Y - 25, 50, 50);
            ımageBox3.Image = my.Resize(100,100,INTER.CV_INTER_CUBIC,true);
            SetTemplate(e.X, e.Y);
            
        }



    }
}
