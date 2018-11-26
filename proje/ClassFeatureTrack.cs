using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Add new references
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

using System.Drawing;

namespace proje
{
    class ClassFeatureTrack
    {
        Point objectLocation = new Point();

        // constructor
        public ClassFeatureTrack(Image<Gray,Byte> inputImage, Image<Gray,Byte> templateImage){
            DetectObjects(inputImage.Copy(), templateImage.Copy());
        }

        // default constructor
        public ClassFeatureTrack() { 
        }

        // Returns Location of the tracked object
        public Point GetLocation()
        {
            return objectLocation;
        }

        public bool TrackObject(Image<Gray, Byte> Input_Image, Image<Gray, Byte> Template)
        {
            return DetectObjects(Input_Image.Copy(), Template.Copy());
        }

        private bool DetectObjects(Image<Gray, byte> input_Image, Image<Gray, byte> object_Image)
        {
            // dft (discrete forrier transform)is the equvalent of continious Forrier Transform 
            // forrier transform is used to decompose the image into its sine and cosine components
            Point dftSize = new Point(input_Image.Width + (object_Image.Width * 2), input_Image.Height + (object_Image.Height * 2));
            bool success = false;

            // image on the new location
            using (Image<Gray, Byte> pad_array = new Image<Gray, Byte>(dftSize.X, dftSize.Y))
            {
                //copy centre
                pad_array.ROI = new Rectangle(object_Image.Width, object_Image.Height, input_Image.Width, input_Image.Height);

                // IntPtr.Zero is static, so will be passed by ref and will not be copied
                CvInvoke.cvCopy(input_Image.Convert<Gray, Byte>(), pad_array, IntPtr.Zero);

                // CvInvoke.cvShowImage("pad_array", pad_array);
                // cut the selected part
                pad_array.ROI = (new Rectangle(0, 0, dftSize.X, dftSize.Y));

                // Compare the selected Object with the original image => MatchTemplate() function 
                // More info at http://docs.opencv.org/doc/tutorials/imgproc/histograms/template_matching/template_matching.html#theory
                using (Image<Gray, float> result_Matrix = pad_array.MatchTemplate(object_Image, TM_TYPE.CV_TM_CCOEFF_NORMED))
                {
                    result_Matrix.ROI = new Rectangle(object_Image.Width, object_Image.Height, input_Image.Width, input_Image.Height);

                    Point[] MAX_Loc, Min_Loc;
                    double[] min, max;
                    result_Matrix.MinMax(out min, out max, out Min_Loc, out MAX_Loc);
                    
                    using (Image<Gray, double> RG_Image = result_Matrix.Convert<Gray, double>().Copy())
                    {
                        //#TAG WILL NEED TO INCREASE SO THRESHOLD AT LEAST 0.8

                        if (max[0] > 0.4)
                        {
                            objectLocation = MAX_Loc[0];
                            success = true;
                        }
                    }
                } // end second using str.
                return success;
            }
        }
    }
}
