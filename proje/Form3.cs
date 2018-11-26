using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Features2D;
using Emgu.CV.Util;
//using OpenCvSharp;
//using OpenCvSharp.CPlusPlus; 

//DiresctShow
using DirectShowLib;
using System.IO.Ports;
namespace proje
{
    public partial class Form3 : Form
    {
      //  private SerialPort serial;

        private Capture _capture = null; //Camera
        private bool _captureInProgress = false; //Variable to track camera state
        int CameraDevice = 0; //Variable to track camera device selected
        Video_Device[] WebCams; //List containing all the camera available

        

        public bool blnFirstTimeInResizeEvent; // used to throw out first time in forms resize event
        // used to save original form and image box sizes
        public int intOrigFormWidth; 
        public int intOrigFormHeight;
        
        // used to resize image box when form is resized
        public int intOrigImageBoxWidth;
        public int intOrigImageBoxHeight;

        public Capture capWebcam;
        public bool blnWebcamCapturingInProgress = false;

        public Image<Bgr, Byte> imgSceneColor = null; // original image scene, in color
        public Image<Bgr, Byte> imgToFindColor = null;// original image to find color

        public Image<Bgr, Byte> imgCopyOfimageToFindWithBorder; // use as copy of a image To find ,  so we can draw a border
                                                                //  on this image without altering original image to find

        public bool blnImageSceneLoaded = false; // flag to keep track if a scene image has been loaded successfully
        public bool blnImageToFindLoaded = false; // flag to keep track if an image to find has been loaded successfully

        // resulting image of image scene and image to find concatenated together 
        public Image<Bgr, Byte> imgResult = null; // with border drawn around found image, and keypoints and matching lines also drawn if chosen
        
        Bgr bgrKeyPointsColor = new Bgr(Color.Blue); // color to draw key points on result image
        Bgr bgrMatchingLinesColor = new Bgr(Color.Green); // color to draw Matching lines on result image
        Bgr bgrFoundImageColor = new Bgr(Color.Red);

        Stopwatch stopwatch = new Stopwatch();
        Timer fpsTimer = new Timer();
        public int fps = 30;

        public int fpsCount=0;
        public int FPScount = 0;
        public double prevMilliSec = 0;
        public double currentMilliSec = 0;
        ImageInfo info = new ImageInfo();
        ServoControlFrame servoForm;
        public bool trackedButtonPushed = false;

        public bool ObjectIsInFourthRectangle=false;

        private double degree = 0;
        public void setDegree(double Degree) {
            degree = Degree;
        }
        public double getDegree() {
            return degree;
        }

        private double newDegree = 0;
        public void setNewDegree(double NewDegree)
        {
            newDegree = NewDegree;
        }
        public double getNewDegree()
        {
            return newDegree;
        }

        public static int count = 0;
        public Form3()
        {
            InitializeComponent();
            intOrigFormHeight = this.Height;
            intOrigFormWidth = this.Width;
            intOrigImageBoxHeight = ibResult.Height;
            intOrigImageBoxWidth = ibResult.Width;

            label4.Text = "Video Area Height : " + info.Height.ToString() + "\nVideo Area Width: " + info.Width.ToString() + "\nScreen Height: " + ibResult.Height + "\nScreen Width: " + ibResult.Width;
           // fpsTimer.Interval = 100/fps;
           // fpsTimer.Start();
           // fpsTimer.Tick += new EventHandler(fpsTimer_Tick);
            settings();
        }

        //void fpsTimer_Tick(object sender, EventArgs e)
        //{
        //    double timeMultiply = 1000 / fpsTimer.Interval;
        //    lblFps.Text = (fpsCount * timeMultiply).ToString(); //Display FPS
        //   // fpsCount = 0;
        //}

        public void settings() {
            DsDevice[] _SystemCamereas = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            WebCams = new Video_Device[_SystemCamereas.Length];
            for (int i = 0; i < _SystemCamereas.Length; i++)
            {
                WebCams[i] = new Video_Device(i, _SystemCamereas[i].Name, _SystemCamereas[i].ClassID); //fill web cam array
                Camera_Selection.Items.Add(WebCams[i].ToString());
            }
            if (Camera_Selection.Items.Count > 0)
            {
                Camera_Selection.SelectedIndex = 0; //Set the selected device the default
                captureButton.Enabled = true; //Enable the start
            }
        
        }

        private void btnFlipHorizontal_Click(object sender, EventArgs e)
        {
            if (capWebcam != null) capWebcam.FlipHorizontal = !capWebcam.FlipHorizontal;
        }



        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_capture != null)
            {
                _capture.Dispose();
            }
           
        }

        private void captureButton_Click(object sender, EventArgs e)
        {
            if (Camera_Selection.SelectedIndex == -1) {
                MessageBox.Show("No Webcam Had Been Choosen");
                return;
            }

            if (_capture != null)
            {
                if (_captureInProgress)
                {
                    //stop the capture
                    captureButton.Text = "Start"; //Change text on button
                    _capture.Pause(); //Pause the capture
                    _captureInProgress = false; //Flag the state of the camera
                    Application.Idle -= new EventHandler(Application_Idle);
                }
                else
                {
                    //Check to see if the selected device has changed
                    if (Camera_Selection.SelectedIndex != CameraDevice)
                    {
                        SetupCapture(Camera_Selection.SelectedIndex); //Setup capture with the new device
                    }
                    captureButton.Text = "Stop"; //Change text on button
                    _capture.Start(); //Start the capture
                    _captureInProgress = true; //Flag the state of the camera
                     Application.Idle +=new EventHandler(Application_Idle);
                }

            }
            else
            {
                //set up capture with selected device
                SetupCapture(Camera_Selection.SelectedIndex);
                //Be lazy and Recall this method to start camera
                captureButton_Click(null, null);
            }
        }

        void Application_Idle(object sender, EventArgs e)
        {
            Image<Bgr, Byte> frame = _capture.RetrieveBgrFrame();
            frame = _capture.QueryFrame();
            if (frame == null) return;
            ibResult.Image = frame;
        }


        private void SetupCapture(int Camera_Identifier)
        {
            //update the selected device
            CameraDevice = Camera_Identifier;

            //Dispose of Capture if it was created before
            if (_capture != null) _capture.Dispose();
            try
            {
                //Set up capture device
                _capture = new Capture(CameraDevice);
              
            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (Application.OpenForms["ServoControlFrame"] == null)
            {
                servoForm = new ServoControlFrame();
            }
            //serial = new SerialPort();
            //if (!serial.IsOpen)
            //{
            //    serial.BaudRate = 19200;
            //    serial.PortName = "COM19";
            //    serial.Open();
                
            //}
        }

        private void btnFlipVertical_Click_1(object sender, EventArgs e)
        {
            if (capWebcam != null) capWebcam.FlipVertical = !capWebcam.FlipVertical;
        }

        private void Form3_Resize(object sender, EventArgs e)
        {
            // This if-else statement is necessary to throw out the first time the Form3_Resize event is called
            if (blnFirstTimeInResizeEvent == true) {
                blnFirstTimeInResizeEvent = false;
            
            } else {
                ibResult.Width = this.Width - (intOrigFormWidth - intOrigImageBoxWidth); // resize image box to form
                ibResult.Height = this.Height - (intOrigFormHeight - intOrigFormHeight);
            }

        }

        private void radioImageFile_CheckedChanged(object sender, EventArgs e)
        {
            if(rdoImageFile.Checked ==true){
                btnStartServo.Enabled = false;
                if(blnWebcamCapturingInProgress == true){
                    // if webcam capturing is in process, remove event from Application Idle
                    Application.Idle -= PerformSURFDetectionAndUpdateGUI;
                    blnWebcamCapturingInProgress = false;
                }

                imgSceneColor = null;
                imgToFindColor = null;
                imgCopyOfimageToFindWithBorder = null;
                imgResult = null;
                blnImageSceneLoaded = false;
                blnImageToFindLoaded = false;


                txtImageScene.Text = "";
                txtImageToFind.Text = "";
                ibResult.Image = null;

                btnStartSurf.Text = "Perform SURF Detection";
                ibResult.Image = null;
                
                // show controls that are used for still images
                lblImageScene.Visible = true;
                lblImageToFind.Visible=true;
                txtImageScene.Visible = true;
                txtImageToFind.Visible = true;
                btnImageScene.Visible = true;
                btnImageToFind.Visible = true;

            }
        }

        private void radioWebcam_CheckedChanged(object sender, EventArgs e)
        {
            if(rdoWebcam.Checked==true){
             //   btnStartServo.Enabled = true;
                // reset variables
                imgSceneColor = null;
                imgToFindColor = null;
                imgCopyOfimageToFindWithBorder = null;
                imgResult = null;
                blnImageSceneLoaded = false;
                blnImageToFindLoaded = false;

                // reset form
                txtImageScene.Text = "";
                txtImageToFind.Text = "";
                ibResult.Image = null;

                try {
                    fpsTimer.Interval = 1000 / fps;
                    capWebcam = new Capture(CameraDevice);
                    
                }catch(Exception ex){
                    MessageBox.Show(". Exception: "+ex.Message);
                    return;
                }
                btnStartSurf.Text = "Get image to track";
                imgToFindColor = null;
                
                Application.Idle += PerformSURFDetectionAndUpdateGUI;
                blnWebcamCapturingInProgress = true;

                // hide controls that are not used with webcam
                lblImageToFind.Visible = false;
                lblImageScene.Visible = false;
                txtImageScene.Visible = false;
                txtImageToFind.Visible = false;
                btnImageScene.Visible = false;
                btnImageToFind.Visible = false;           
            }
        }

        private void btnChooseOrgImg_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = ofdImageScene.ShowDialog();
            
            // dialogResult = System.Windows.Forms.DialogResult.Yes
            if ( dialogResult== DialogResult.OK || dialogResult == DialogResult.Yes )
            {
                txtImageScene.Text = ofdImageScene.FileName;   

            }else{
                return;
            }

            try {
                imgSceneColor = new Image<Bgr, byte>(txtImageScene.Text); // read image from file
            }catch(Exception ex){
                this.Text = ex.Message;
                return;
            }

            blnImageSceneLoaded = true; // if we get here scene image is loaded successfully
            if (blnImageToFindLoaded == false) // if to find image  has not been loaded yet 
            {                                  // show image scene we just loaded on image box
                ibResult.Image = imgSceneColor; 
            }
            else {
                // if to find image  has already been loaded
                // in the same image box, show webcam and image, that we are willing to find, together
                ibResult.Image = imgSceneColor.ConcateHorizontal(imgCopyOfimageToFindWithBorder);

            }
            
        }

        private void btnChooseSubImg_Click(object sender, EventArgs e)
        {
            DialogResult dialogRslt = ofdImageToFind.ShowDialog();
            if(dialogRslt == DialogResult.OK || dialogRslt == DialogResult.Yes){
                txtImageToFind.Text = ofdImageToFind.FileName;

            }
            else { return; }

            try {
                imgToFindColor = new Image<Bgr, byte>(txtImageToFind.Text);

            }catch(Exception ex){
                this.Text = ex.Message;
                return;
            }

            blnImageToFindLoaded =true; // if we get here, to find image loaded successfully

            // make a copy of to find image, so we can draw on the copy,therefore not changing the original image to find
            imgCopyOfimageToFindWithBorder = imgToFindColor.Copy();

            // draw 2 pixel wide border around the copy of the image to find, use same color as box for found image
            imgCopyOfimageToFindWithBorder.Draw(new Rectangle(1, 1, imgCopyOfimageToFindWithBorder.Width - 3, imgCopyOfimageToFindWithBorder.Height - 3), bgrFoundImageColor, 2);

            if (blnImageSceneLoaded == true) {
                // concat to find image with border to scene image , show result on imag
                ibResult.Image = imgSceneColor.ConcateHorizontal(imgCopyOfimageToFindWithBorder); 
            } else { // if scene image has not already been loaded 
                // show to find image border we just loade on image box
                ibResult.Image = imgCopyOfimageToFindWithBorder;
              
            }
        
        }

        private void txtImageScene_TextChanged(object sender, EventArgs e)
        {
            // move caret to end of the text box so file name is visible rather than file ext.
            txtImageScene.SelectionStart = txtImageScene.Text.Length;
        }

        private void txtImageToFind_TextChanged(object sender, EventArgs e)
        {
            txtImageToFind.SelectionStart = txtImageToFind.Text.Length;
        }

        private void btnStartSurf_Click(object sender, EventArgs e)
        {
            if (Camera_Selection.SelectedIndex == -1)
            {
                btnStartServo.Enabled = false;
                MessageBox.Show("No Webcam Had Been Choosen");
                return;
            }   
            if (rdoImageFile.Checked == true) {
                btnStartServo.Enabled = false;
                if(string.IsNullOrEmpty(txtImageScene.Text)== false && string.IsNullOrEmpty(txtImageToFind.Text)==false){
                    PerformSURFDetectionAndUpdateGUI(new Object(), new EventArgs());
                    txtRadius.Clear();
                }else{
                    MessageBox.Show("Please update an image to track ");
                }
            }else if(rdoWebcam.Checked == true ){ // if using webcam
              //  btnStartServo.Enabled = true;
                // use most recent image from webcam , which will be in imgSceneColor, then shrink and save as new image 
                imgToFindColor = imgSceneColor.Resize(328,240,INTER.CV_INTER_CUBIC,true);
                
                info.Height = imgToFindColor.Height;
                info.Width = imgToFindColor.Width;
                int x = ibResult.Location.X;
                label4.Text = "X: " + x.ToString() + "\nY: " + ibResult.Location.Y.ToString() + "\nVideo Area Height : " + ibResult.Height.ToString() + "\nVideo Area Width: " + (ibResult.Width - info.Width).ToString() + "\nİmageToFind Height: " + info.Height + "\nImageToFind Width: " + info.Width;
                btnStartSurf.Text = "Upload Image To Track";
                trackedButtonPushed = true;
                btnStartServo.Enabled = true;
               // fpsTimer.Start();
            }

           
        }

        private void chckBoxKeyPnt_CheckedChanged(object sender, EventArgs e)
        {
            if (ckDrawKeyPoints.Checked == false) {
                ckDrawMatchingLines.Checked = false;
                ckDrawMatchingLines.Enabled = false;
            }else if( ckDrawKeyPoints.Checked ==true){
                ckDrawMatchingLines.Enabled = true;
            }

            if(rdoImageFile.Checked == true){
                // call SURF button click event to update image for draw key points check box change
                btnStartSurf_Click(new Object(), new EventArgs());
            }


        }

        private void chkBoxMatchLine_CheckedChanged(object sender, EventArgs e)
        {
            if(rdoImageFile.Checked==true){ // if using image from file
                //  call SURF button click event to  update image for draw matching lines check box change 
                btnStartSurf_Click(new Object(), new EventArgs()); 
            }
        }

        public ServoClass servoCls;
        private void PerformSURFDetectionAndUpdateGUI(object sender, EventArgs arg) {
             
           
            
            if(rdoImageFile.Checked==true){
              grpZoneInfo.Visible = false;
              label4.Visible = false;
                txtRadius.Text = "";
                txtRadius.Clear();
                 // indicates that we dont have any images
                 if(blnImageSceneLoaded ==false || blnImageToFindLoaded ==false || imgSceneColor==null || imgToFindColor ==null ){
                     MessageBox.Show("No İmages Loaded, Please Choose Both Images Before Perform SURF");
                     return;
                 }
                 this.Text = "Processing..... , Please wait";
                 Application.DoEvents(); // processes all messages that waiting on the queue
                 stopwatch.Restart();
             }else if(rdoWebcam.Checked== true){
                // Image<Bgr, byte> img;
                 try {
                     // if we are using HD camera,
                     // capWebcam.QueryFrame().Resize(0.5, Emgu.CV.CvEnum.INTER.CV_INTER_AREA);
                     // function is better to use
                  
                    //fpsTimer.Tick +=new EventHandler(fpsTimer_Tick);
                     imgSceneColor = capWebcam.QueryFrame();
                     stopwatch.Start();
                     // fpsTimer.Start();
                     // fpsCount++;
                   
                 }catch(Exception ex){
                     MessageBox.Show("Exception: "+ex.Message);
                     return;
                 }

                 if (imgSceneColor == null)
                 { // if next frame was not read successfully from webcam into the scene image variable
                     this.Text = "Image Scene is Null"; // error
                     return;
                 }

                 if(imgToFindColor == null  ){ // if we dont have an image to track yet,
                     ibResult.Image = imgSceneColor; // show scene image on image box
                     return;
                 }
             }
             // if we get here, we know both color images are good, so begin SURF detection
             // ----------------------- SURF -------------------------
            
            // can be changed as 50 
            SURFDetector surfDetecter = new SURFDetector(500, false); // hessian treshold is set to 500 depending on the sharpness etc features of the image

            Image<Gray, Byte> imgSceneGray = null;
            Image<Gray, Byte> imgToFindGray = null;

            VectorOfKeyPoint vkpSceneKeyPoints;
            VectorOfKeyPoint vkpToFindKeyPoints;

            // "Single" => float  
            Matrix<Single> mtxSceneDescriptors; // matrix of descriptors to be queried for nearest neighbors
            Matrix<Single> mtxToFindDescriptors; // matrix of descriptors for to find image

            // knnMatch returns two closest descriptors from the query set for every descriptor from the train set
            Matrix<int> mtxMatchIndices; // matrix of descriptors to be queried for nearest neigbors (call to KnnMatch()) 
            Matrix<Single> mtxDistance;  // matrix of distance values, will result from training descriptors (call to KnnMatch()) 
            Matrix<Byte> mtxMask; // indicates which row is valid for the matches
            
            // WARNING! This structure is slowing down the program.Bc for each descriptor in the first set this matcher finds the 
            // closest descriptor in the second set by TRYING EACH ONE 
            // Look at http://stackoverflow.com/questions/7296915/opencv-object-matching-using-surf-descriptors-and-bruteforcematcher
            // use Ransac Method instead. Info at 
            // http://stackoverflow.com/questions/10059162/getting-the-5-points-used-by-ransac-in-findhomography-opencv-for-android
            // http://opencv-users.1802565.n2.nabble.com/How-to-use-cv-FindHomography-td7229892.html
            BruteForceMatcher<Single> bruteForceMatcher;
            HomographyMatrix homographyMatrix = null; // used for setting location of found image in scene image 

            int intKNumNearestNeighbors = 2; // k, number of nearest neighbors to search for
            double dbUniqunessTreshold=0.8;  // the distance difference ratio for a match to be considered unique

            int intNumNonZeroElements; // used as return value for number of nonzero elements both in matrix mask, and also from call to GetHomographyMatrixFromMatchedFeatures()

            // params for use with call to VoteForSizeAndOrientation()
            double dblScaleIncremenet=1.5; // determines the difference in scale neighboring bins
            int intRotationBins =20; // number of bins for rotation out of 360 degrees, e.g: if set to 20, each bin covers 18 deg (20*18=360)

            double dbRansacReprojectionTreshold = 2.0; // for use with GetHomographyMatrixFromMatchedFeatures(), the minimum allowed reprojection error to treat a point pair as an inlier 

            Rectangle rectImageToFind= new Rectangle(); // rectange encompassing the entire image to find
            PointF[] ptfPointsF; // 4 points defining box around location of found image in scene, in float type (or Single)
            Point[] ptPoints;//  4 points defining box around location of found image in scene, in int type

            // To use SURF features, We have to convert images to Grayscale 
            imgSceneGray = imgSceneColor.Convert<Gray, Byte>();//.PyrUp().PyrDown().Canny(new Gray(100), new Gray(60));
            imgToFindGray = imgToFindColor.Convert<Gray, Byte>();//.PyrUp().PyrDown().Canny(new Gray(100), new Gray(60));

            vkpSceneKeyPoints = surfDetecter.DetectKeyPointsRaw(imgSceneGray, null); // detect the key points in the scene (2nd param is mask, we assign it null)
            mtxSceneDescriptors= surfDetecter.ComputeDescriptorsRaw(imgSceneGray,null,vkpSceneKeyPoints); // compute scene descriptor

            vkpToFindKeyPoints = surfDetecter.DetectKeyPointsRaw(imgToFindGray,null);
            mtxToFindDescriptors = surfDetecter.ComputeDescriptorsRaw(imgToFindGray,null,vkpToFindKeyPoints);

            bruteForceMatcher = new BruteForceMatcher<Single>(DistanceType.L2); // L2, squared euclidean distance 
            bruteForceMatcher.Add(mtxToFindDescriptors); // add matrix to find decriptors brute force matcher 

            mtxMatchIndices = new Matrix<int>(mtxSceneDescriptors.Rows, intKNumNearestNeighbors); // instantate the indices matrix, params are rows and columns
            mtxDistance = new Matrix<Single>(mtxSceneDescriptors.Rows,intKNumNearestNeighbors); //

            bruteForceMatcher.KnnMatch(mtxSceneDescriptors,mtxMatchIndices,mtxDistance,intKNumNearestNeighbors,null); // find K-nearest match 

            mtxMask = new Matrix<Byte>(mtxDistance.Rows,1);
            mtxMask.SetValue(255); // set value of all elements in mask matrix 

            Features2DToolbox.VoteForUniqueness(mtxDistance, dbUniqunessTreshold, mtxMask); // filter the matched features,such that if it is not unique 

            intNumNonZeroElements = CvInvoke.cvCountNonZero(mtxMask); // get number of non-zero elements in mask matrix 
            if (intNumNonZeroElements >= 4) { // if at least 4
                // eliminate the matched features whose scale and rotation do not agree with the majority's scale and rotation
                intNumNonZeroElements = Features2DToolbox.VoteForSizeAndOrientation(vkpToFindKeyPoints,vkpSceneKeyPoints,mtxMatchIndices,mtxMask,dblScaleIncremenet,intRotationBins);

                // note : Homography describes the mapping across two planes or what happens during pure camera rotation.
                if (intNumNonZeroElements >= 4) // if still at least 4 non-zero elements 
                {
                    // get the homopgraphy matrix from RANSAC (random simple consensus)
                    homographyMatrix = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures(vkpToFindKeyPoints,vkpSceneKeyPoints,mtxMatchIndices,mtxMask,dbRansacReprojectionTreshold);
                }
            }

            // ---------------- DRAW BORDER AROUND TO FIND IMAGE ------------------------------

            // Make a copy of the image to find, so we can draw on the copy, therefore no changing the original image to find 
            imgCopyOfimageToFindWithBorder = imgToFindColor.Copy();
            // draw a 2 pixel wide border around the image to find, we use the same color as box for found image  
           
            imgCopyOfimageToFindWithBorder.Draw(new Rectangle(1,1,imgCopyOfimageToFindWithBorder.Width-3,imgCopyOfimageToFindWithBorder.Height-3),bgrFoundImageColor,2); // the last param (2) represents 2 pixels as thickness

            // next we will draw the scene image and image to find together in the result image
            // 3 conditionals are neccessary, depending on which check boxes are checked (draw key pnts / or dram matching lines)
            if(ckDrawKeyPoints.Checked== true && ckDrawMatchingLines.Checked == true){
                // draw both key pnts and matching lines
                // combines scene image and copy of image to find into result , then draw key pnts and matching lines in one step 
                imgResult = Features2DToolbox.DrawMatches<Bgr>(imgCopyOfimageToFindWithBorder,vkpToFindKeyPoints,imgSceneColor,vkpSceneKeyPoints,mtxMatchIndices,bgrMatchingLinesColor,bgrKeyPointsColor,mtxMask,Features2DToolbox.KeypointDrawType.DEFAULT);
            }
            else if (ckDrawKeyPoints.Checked == true && ckDrawMatchingLines.Checked == false)
            {
                // draw only key pnts
                // draw scene with keypoints on result image 
                imgResult = Features2DToolbox.DrawKeypoints<Bgr>(imgSceneColor,vkpSceneKeyPoints,bgrKeyPointsColor,Features2DToolbox.KeypointDrawType.DEFAULT);

                // then draw key points on copy of image to find
                imgCopyOfimageToFindWithBorder = Features2DToolbox.DrawKeypoints<Bgr>(imgCopyOfimageToFindWithBorder,vkpToFindKeyPoints,bgrKeyPointsColor,Features2DToolbox.KeypointDrawType.DEFAULT);
                
                imgResult = imgResult.ConcateHorizontal(imgCopyOfimageToFindWithBorder); // concat copy of image to find onto result img
            }
            else if (ckDrawKeyPoints.Checked == false && ckDrawMatchingLines.Checked == false) { 
                // draw none 
                imgResult = imgSceneColor; // assing scene image to the result image
                imgResult = imgResult.ConcateHorizontal(imgCopyOfimageToFindWithBorder);
            }

         //   grpZoneInfo.Visible = true;
         //   label4.Visible = true;
           
            // to project point functions we will use Homography functions
            // check to make sure that homograpy matrix is not null, bc in a moment we will call a homography function
            // in this next portion we draw a border on the scene portion of the result image, around where the found object is located 
            if(homographyMatrix != null){
                rectImageToFind.Y = 0;
                rectImageToFind.X = 0; // to start with, set the rectangle to be the full size of image to find
               
                rectImageToFind.Width = imgToFindGray.Width;
                rectImageToFind.Height = imgToFindGray.Height;

                ptfPointsF = new PointF[]{ new PointF(rectImageToFind.Left,rectImageToFind.Top),
                                           new PointF(rectImageToFind.Right,rectImageToFind.Top),
                                           new PointF(rectImageToFind.Right,rectImageToFind.Bottom),
                                           new PointF(rectImageToFind.Left,rectImageToFind.Bottom)};

                // ProjectPoints() will set ptfPointsF (pass by reference) to be the location of a box in the scene portion of the
                // result image, where the box surrounds the image we are looking for
                homographyMatrix.ProjectPoints(ptfPointsF);

                // convert from type PointF to type Point, this is necessary bc ProjectPoints() takes type PointF but DrawPolyLine() takes type Point
                ptPoints = new Point[]{  Point.Round(ptfPointsF[0]),
                                         Point.Round(ptfPointsF[1]),
                                         Point.Round(ptfPointsF[2]),
                                         Point.Round(ptfPointsF[3])};
               
                // Draw the border around found object
                imgResult.DrawPolyline(ptPoints,true,bgrFoundImageColor,2); // draw border around the found image in scene portion of result image 
               
                ibResult.Image = imgResult;
                
                TimeSpan ts = stopwatch.Elapsed;
                currentMilliSec += ts.TotalMilliseconds - prevMilliSec;
                prevMilliSec = ts.TotalMilliseconds;
                FPScount += 1;
                float x1 = 0;
                float x2;
                float y1 = 0;
                float y2;
                float Vx;
                Point objectPoint= new Point();
                String classify;
                int denemeCount=0;
                bool isYNegative = false;
                bool isXNegative = false;
                servoCls = new ServoClass();
                  foreach (PointF pointf in ptfPointsF)
                  {
                      

                      x2 = ptfPointsF[0].X;
                      y2 = ptfPointsF[0].Y;
                     
                     //  x2 = pointf.X;
                     //  y2 = pointf.Y;
                      if (denemeCount == 0 || denemeCount == 4)
                      {
                          
                          if (x2 > x1)
                          {
                             

                              float X = x2 - x1;
                              Vx = X;
                              // y2>y1 ise +y yönünde hareket
                              classify = (y2 > y1) ? ((y2 - y1) / FPScount).ToString("###.000") : ((y1 - y2) / FPScount).ToString("###.000");
                              string classify_2;
                              objectPoint.X = (int)X;
                              if (y2 > y1)
                              {
                                  objectPoint.Y = (int)(y2 - y1);
                                  classify_2 = (" and +Y direction at the angle of  " + (y2 - y1).ToString("###.000"));
                                  
                              }
                              else
                              {
                                  objectPoint.Y = (int)(y1 - y2);
                                  classify_2 = (" and -Y direction at the angle of  " + (y1 - y2).ToString("###.000"));
                                  isYNegative = true;
                              }


                              if (currentMilliSec >= 1000.0f)
                              {
                                  label3.Text = (Vx / FPScount).ToString("###.000");
                                  //  label5.Text = "(y2 - y1) / fpsCount : " + ((y2 - y1) / FPScount).ToString("###.000");
                                  if (txtRadius.Text != "") txtRadius.AppendText(Environment.NewLine);
                                  txtRadius.AppendText("FPS: " + FPScount.ToString() + "  " + "   MilliSeconds:" + currentMilliSec.ToString("###.000").PadLeft(4).PadRight(15) +
                                      "Object is moving in the positive +X direction, at the angle of " + X.ToString("###.000") + " degrees " + classify_2.ToString() + "Vx: ".PadLeft(10) + label3.Text + "  degree/fps" + "Vy: ".PadLeft(10) + classify.ToString() + "  degree/fps" + "\r\n");
                                  txtRadius.ScrollToCaret();
                                  FPScount = 0;
                                  currentMilliSec = 0;
                              }

                            //  if (ObjectIsInFourthRectangle == false)
                              {
                                  if (isYNegative == false)
                                  {
                                      servoCls.TurnServoXRight();
                                      servoCls.TurnServoYLeft();
                                  }
                                  if (isYNegative == true)
                                  {
                                      servoCls.TurnServoXRight();
                                      servoCls.TurnServoYRight();
                                  }
                              }

                              

                          }
                          else if (x1 > x2)
                          {
                              isXNegative = true;
                              float negativeX = x1 - x2;
                              objectPoint.X = (int)negativeX;
                              Vx = negativeX;
                              classify = (y2 > y1) ? ((y2 - y1) / FPScount).ToString("###.000") : ((y1 - y2) / FPScount).ToString("###.000");
                              string classify_2;
                              if (y2 > y1)
                              {
                                  objectPoint.Y = (int)(y2 - y1);
                                  classify_2 = (" and +Y direction at the angle of  " + (y2 - y1).ToString("###.000"));
                              }
                              else
                              {
                                  objectPoint.Y = (int)(y1 - y2);
                                  classify_2 = (" and -Y direction at the angle of  " + (y1 - y2).ToString("###.000"));
                                  isYNegative = true;
                              }
                              if (currentMilliSec >= 1000.0f)
                              {
                                  label3.Text = (Vx / FPScount).ToString("###.000");
                                  // label5.Text = "(y2 - y1) / fpsCount : " + ((y2 - y1) / FPScount).ToString();
                                  if (txtRadius.Text != "") txtRadius.AppendText(Environment.NewLine);
                                  txtRadius.AppendText("FPS: " + FPScount.ToString() + "  " + "   MilliSeconds:" + currentMilliSec.ToString("###.000").PadLeft(4).PadRight(15) +
                                      "Object is moving in the negative -X direction, at the angle of " + negativeX.ToString("###.000") + " degrees" + classify_2.ToString() + "Vx: ".PadLeft(10) + label3.Text + "  degree/fps" + "Vy: ".PadLeft(10) + classify.ToString() + "  degree/fps" + "\r\n");
                                  txtRadius.ScrollToCaret();
                                  FPScount = 0;
                                  currentMilliSec = 0;
                              }

                            //  if (!ObjectIsInFourthRectangle)
                              {
                                  if (isYNegative == false)
                                  {
                                      servoCls.TurnServoXLeft();
                                      servoCls.TurnServoYLeft();
                                  }
                                  if (isYNegative == true)
                                  {
                                      servoCls.TurnServoXLeft();
                                      servoCls.TurnServoYRight();
                                  }
                              }
                          }

                          DivideScreen(objectPoint);
                          if (firstTime)
                          {
                              RunServo(objectPoint);
                              firstTime = false;
                          }

                          x1 = x2;
                          y1 = y2;
                          count++;
                          if (count == 5)
                          {
                              if (!firstTime)
                              {
                                  RunServo2(objectPoint);
                                  firstTime = true;
                              }

                              degree = newDegree;
                              count = 0;
                          }denemeCount = 0;
                      }
                      denemeCount++;
                    }
                  servoCls.ClosePort();

                    if (rdoImageFile.Checked == true)
                    {
                        stopwatch.Stop();
                        lblProcessingTime.Visible = true;
                        lblProcessingTime.Text = "Processing Time= " + stopwatch.Elapsed.TotalSeconds.ToString("###.000") + " sec, done processing ";
                        txtRadius.Text = "";
                    }
            }// end if
         }

        public bool firstTime = true;

        void fpsTimer_Tick(object sender, EventArgs e)
        {
            imgSceneColor = capWebcam.QueryFrame();
            setImage(imgSceneColor);
        }

        public void setImage(Image<Bgr,byte> img) {
            imgSceneColor = img;
        }
        public Image<Bgr, byte> getImage() {
            return imgSceneColor;
        }
        

        int screenWidth;
        int screenX;
        int screenY;
        int screenHeight; 
        Rectangle rectangleOne;
        Rectangle rectangleTwo;
        Rectangle rectangleThree;
        Rectangle rectangleFour;
        Rectangle region1;
        Rectangle region2;
        Rectangle region3;
        Rectangle region4;
        bool ObjectIsTheCenter = false;
        public void DivideScreen(Point trackingObjectPoint) {
           Point imgBoxXCord= ibResult.Location;
           
           screenX =  imgBoxXCord.X;
           screenY = imgBoxXCord.Y;
           screenWidth =ibResult.Width- info.Width;//ibResult.Width;
           screenHeight = ibResult.Height;//ibResult.Height;

           // rectangle One
           rectangleOne.Width = screenWidth / 2;
           rectangleOne.Height = screenHeight / 2;
           rectangleOne.X = rectangleOne.Width / 2;
           rectangleOne.Y = rectangleOne.Height / 2;
           // rectangle Two
           rectangleTwo.Width = rectangleOne.Width / 2;
           rectangleTwo.Height = rectangleOne.Height / 2;
           rectangleTwo.X = rectangleTwo.Width / 2 + rectangleOne.X;
           rectangleTwo.Y = rectangleTwo.Height / 2 + rectangleOne.Y;
           // rectangle Three
           rectangleThree.Width = rectangleTwo.Width / 2;
           rectangleThree.Height = rectangleTwo.Height / 2;
           rectangleThree.X = rectangleThree.Width / 2 + rectangleTwo.X;
           rectangleThree.Y = rectangleThree.Height / 2 + rectangleTwo.Y;
           // rectangle Four ( inner rectangle )
           rectangleFour.Width = rectangleThree.Width / 2;
           rectangleFour.Height = rectangleThree.Height / 2;
           rectangleFour.X = rectangleFour.Width / 2 + rectangleThree.X;
           rectangleFour.Y = rectangleFour.Height / 2 + rectangleThree.Y;
           
           // ----------- Calculate Quadrants in RectangleFour -------------
           region1.Width = region2.Width = region3.Width = region4.Width = rectangleFour.Width / 2 ;
           region1.Height = region2.Height = region3.Height = region4.Height = rectangleFour.Height / 2;
           // Region 1
           region1.X = rectangleFour.X + region1.Width;
           region1.Y = rectangleFour.Y + region1.Height;
           // Region 2
           region2.X = rectangleFour.X;
           region2.Y = rectangleFour.Y + region2.Height;
           // Region 3
           region3.X = rectangleFour.X;
           region3.Y = rectangleFour.Y;
           // Region 4
           region4.X = rectangleFour.X + region4.Width;
           region4.Y = rectangleFour.Y;

           // ------ Find Tracking Object's Region
           if ( (trackingObjectPoint.X > rectangleFour.X && trackingObjectPoint.X < rectangleFour.X+rectangleFour.Width)
                 || trackingObjectPoint.Y > rectangleFour.Y && trackingObjectPoint.Y < rectangleFour.Y+ rectangleFour.Height )
           {

               // trackingObjectPoint is in RectangleFour
               lblZone.Text = "Tracking Object" + "\n\r" + " is in the 4th Rectangle";
               ObjectIsTheCenter = true;
               lblQuad.Visible = true;
               lblQuadValue.Visible = true;
               //----- Find Tracking Object's Quadrant 
               if (trackingObjectPoint.X >= region1.X && trackingObjectPoint.X <= region1.X + region1.Width && trackingObjectPoint.Y >= region1.Y && trackingObjectPoint.Y <= region1.Y + region1.Height)
               {
                   // trackingObjectPoint is in the First Region
                   lblQuadValue.Text = "Tracking Object" + "\n\r" + " is in the First Region ";
                   
               }
               else if (trackingObjectPoint.X >= region2.X && trackingObjectPoint.X < region2.X + region2.Width && trackingObjectPoint.Y >= region2.Y && trackingObjectPoint.Y <= region2.Y + region2.Height)
               {
                   // trackingObjectPoint is in the Second Region
                   lblQuadValue.Text = "Tracking Object " + "\n\r" + "is in the Second Region ";
               }
               else if (trackingObjectPoint.X >= region3.X && trackingObjectPoint.X < region3.Y + region3.Width && trackingObjectPoint.Y >= region3.Y && trackingObjectPoint.Y < region3.Y + region3.Height)
               {
                   // trackingObjectPoint is in the Third Region
                   lblQuadValue.Text = "Tracking Object" + "\n\r" + " is in the Third Region ";
               }
               else if (trackingObjectPoint.X >= region4.X && trackingObjectPoint.X <= region4.Width && trackingObjectPoint.Y >= region4.Y && trackingObjectPoint.Y < region4.Y + region4.Height)
               {
                   // trackingObjectPoint is in the Fourth Region
                   lblQuadValue.Text = "Tracking Object" + "\n\r" + " is in the Fourth Region ";
               }
               else {
                   lblQuad.Visible = false;
                   lblQuadValue.Visible = false;
               }
           
               

           }
           else if ((trackingObjectPoint.X >= rectangleThree.X) && ((trackingObjectPoint.X <= rectangleFour.X) ||
                      (trackingObjectPoint.X >= rectangleFour.X + rectangleFour.Width && trackingObjectPoint.X <= rectangleThree.X + rectangleThree.Width)
                      || (trackingObjectPoint.X >= rectangleFour.X && trackingObjectPoint.X <= rectangleFour.X + rectangleFour.Width))
                      && ( ( trackingObjectPoint.Y >= rectangleThree.Y) && ( (  trackingObjectPoint.Y <= rectangleFour.Y) || 
                      (trackingObjectPoint.Y >= rectangleFour.Y + rectangleFour.Height && trackingObjectPoint.Y <= rectangleThree.Y + rectangleThree.Height)  
                      || (trackingObjectPoint.Y >= rectangleFour.Y && trackingObjectPoint.Y <= rectangleFour.Y + rectangleFour.Height )) ) )
           {
               lblQuad.Visible = false;
               lblQuadValue.Visible = false;

               // trackingObjectPoint is in RectangleThree
               lblZone.Text = "Tracking Object" + "\n\r" + "is in the 3th Rectangle";

           }
           else if (  ( (trackingObjectPoint.X >= rectangleTwo.X)  && ( ( trackingObjectPoint.X < rectangleThree.X) || (
                   ( trackingObjectPoint.X > rectangleThree.X + rectangleThree.Width &&  trackingObjectPoint.X <= rectangleTwo.X + rectangleTwo.Width) 
                   || (  trackingObjectPoint.X >= rectangleThree.X && trackingObjectPoint.X <= rectangleThree.X + rectangleThree.Width ) )))
                   &&  (  ( trackingObjectPoint.Y > rectangleTwo.Y) && ( (trackingObjectPoint.Y < rectangleThree.Y) || ( trackingObjectPoint.Y > rectangleThree.Y &&
                   trackingObjectPoint.Y <= rectangleTwo.Y + rectangleTwo.Height) || ( trackingObjectPoint.Y >= rectangleThree.Y && 
                   trackingObjectPoint.Y <= rectangleThree.Y + rectangleThree.Height ))))
          {
              lblQuad.Visible = false;
              lblQuadValue.Visible = false;
              // trackingObjectPoint is in RectangleTwo 
              lblZone.Text = "Tracking Object " + "\n\r" + "is in the 2nd Rectangle";

          }else if ( ( ( trackingObjectPoint.X >= rectangleOne.X ) && ( ( trackingObjectPoint.X < rectangleTwo.X ) ||
                   (  trackingObjectPoint.X > rectangleTwo.X + rectangleTwo.Width && trackingObjectPoint.X <= rectangleOne.X + rectangleOne.Width )
                   || ( trackingObjectPoint.X >= rectangleTwo.X && trackingObjectPoint.X <= rectangleTwo.X +rectangleTwo.Width)))
                   && ( ( trackingObjectPoint.Y >= rectangleOne.Y ) && ( ( trackingObjectPoint.Y < rectangleTwo.Y ) || 
                   (trackingObjectPoint.Y > rectangleTwo.Y + rectangleTwo.Height && trackingObjectPoint.Y <= rectangleOne.Y + rectangleOne.Height )
                   || (trackingObjectPoint.X >= rectangleTwo.X && trackingObjectPoint.Y <= rectangleTwo.Y + rectangleTwo.Height))))        
           {
               lblQuad.Visible = false;
               lblQuadValue.Visible = false;
               // trackingObjectPoint is in RectangleOne 
               lblZone.Text = "Tracking Object " + "\n\r" + "is in the 1th Rectangle";

           }

           if (ObjectIsTheCenter == false) { 
           
           }
          

           if (Application.OpenForms["ServoControlFrame"] != null)
           {
               if (!servoForm.clickedClosed)
               {
                   if (servoForm.port.IsOpen)
                   {
                       Font font = new Font("Comic Sans", 10.0f,FontStyle.Bold);
                       servoForm.FindServoPosition(trackingObjectPoint, screenWidth, screenHeight);
                       servoForm.label3.Visible = true;
                       servoForm.label3.Font = font;
                       servoForm.label3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FC004B");
                       servoForm.label3.Text = "Object is being tracked";
                   }
               }
           }
            

        }
     
        public bool isInCenter;
        public void RunServo(Point trackingObjectLocation) {
            ServoPositionClass servoCls = new ServoPositionClass();
            Rectangle centerRect= servoCls.CreateCenterRectangle((ibResult.Width - info.Width), ibResult.Height);
            setDegree( servoCls.CalculateDegree(trackingObjectLocation, ibResult.Location.X, ibResult.Location.Y));
            isInCenter = servoCls.IsObjectInCenter(trackingObjectLocation, centerRect);
            #region 
            // if (!firstTime)
            {

                //if (!isInCenter)
                //{
                //    setNewDegree( servoCls.CalculateNewDegree(trackingObjectLocation, ibResult.Location.X, ibResult.Location.Y));
                //    rotationDegree = servoCls.CalculateRotationDegree(degree,newDegree);

                //    if (textBox1.Text != "") textBox1.AppendText(Environment.NewLine);
                //    textBox1.AppendText("Count: " + count + "   Centerda mı?" + isInCenter.ToString() + "   newDegree: " + getNewDegree().ToString() + "   şu anki degree:" + getDegree().ToString() + " rotation degree" + rotationDegree.ToString());
                //}
                //firstTime = true;
            } 
            #endregion

            // textBox1.AppendText(" X:  " + trackingObjectLocation.X+"   Y: "+trackingObjectLocation.Y); 
            textBox1.ScrollToCaret();
            firstTime = false;
        }
        
        public void RunServo2(Point trackingObjectLocation)
        {
            ServoPositionClass servoCls = new ServoPositionClass();
            Rectangle centerRect = servoCls.CreateCenterRectangle((ibResult.Width - info.Width), ibResult.Height);
            double rotationDegree = 0;
            if (!isInCenter)
            {
                setNewDegree(servoCls.CalculateNewDegree(trackingObjectLocation, ibResult.Location.X, ibResult.Location.Y));
                rotationDegree = servoCls.CalculateRotationDegree(getDegree(), getNewDegree());

                if (textBox1.Text != "") textBox1.AppendText(Environment.NewLine);
                textBox1.AppendText("Count: " + count + "   Is in the center :" + isInCenter.ToString() + "   newDegree: " + getNewDegree().ToString() + "   Current degree:" + getDegree().ToString() + " Rotation degree: " + rotationDegree.ToString());
            }
            firstTime = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rdoWebcam.Checked == true)
            {
                if (Application.OpenForms["ServoControlFrame"] == null)
                {
                    servoForm.Left = 860;
                    servoForm.Top = 340;
                    servoForm.ShowDialog();

                }
            }
        }
     
    }
}
