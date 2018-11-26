using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace proje
{
    public class ServoPositionClass
    {
        public int centerRectWidth;
        public int centerRectHeight;
        public int centerRectX;
        public int centerRectY;
        public Rectangle centerRectangle;
        public double hypotenuse;
        public double sideB; // opposite
        public double sideC; // adjacent
        private double degree; // object's current location's alfa degree (triangle)
        private double newDegree;
        public double rotationDegree;

        //ibResult tan gelen W,H,X,Y alınacak
        public Rectangle CreateCenterRectangle(int ibResultWidth, int ibResultHeight){

            centerRectWidth = ibResultWidth / 2;
            centerRectHeight = ibResultHeight / 2;

            centerRectX = centerRectWidth / 2;
            centerRectY = centerRectHeight / 2;

            centerRectangle = new Rectangle(centerRectX, centerRectY, centerRectWidth, centerRectHeight);
            return centerRectangle;
        }

        // get the object's current location, and check wheater it is in the center rectangle
        public bool IsObjectInCenter(Point objectLocation, Rectangle centerRect)
        {
            
            if (objectLocation.X < centerRect.X + centerRect.Width && objectLocation.X > centerRect.X &&
                objectLocation.Y < centerRect.Y + centerRect.Height && objectLocation.Y > centerRect.Y)
            {
                return true;

            }
            else {
                return false;
            }
        }

        
        // for tracking the object calculate degree
        public double CalculateDegree(Point objectLocation, int ibResultX, int ibResultY)
        {
            if (objectLocation.X > ibResultX)
            {
                sideC = (double)objectLocation.X - ibResultX;
            }
            else
            {
                sideC = (double)(-1) * (objectLocation.X - ibResultX);
            } if (objectLocation.Y > ibResultY)
            {
                sideB = (double)objectLocation.Y - ibResultY;
            }
            else
            {
                sideB = (double)(-1) * (objectLocation.Y - ibResultY);
            }
            hypotenuse = Math.Sqrt( (sideC *sideC) + (sideB* sideB));

            // cosDegree is the cosinus of the missing degree
           // double cosDegree = (Math.Pow(sideB, 2) - Math.Pow(hypotenuse, 2) - Math.Pow(sideC, 2)) / (-2 * sideC * hypotenuse);
            double cosDegree =(Math.Pow(hypotenuse, 2) + Math.Pow(sideC, 2)- Math.Pow(sideB, 2) )/(2*hypotenuse*sideC);
            degree = Math.Acos(cosDegree);// degree in radiants
            degree = RadianToDegree(degree); // degree in degrees
            setDegree(Math.Floor( degree)); // set degree info
            return degree;
        }

        // for tracking the object calculate new location degree
        public double CalculateNewDegree(Point objectLocation, int ibResultX, int ibResultY)
        {
            if (objectLocation.X > ibResultX)
            {
                sideC = (double)objectLocation.X - ibResultX;
            }
            else {
                sideC = (double)(-1)* (objectLocation.X - ibResultX);
            } if (objectLocation.Y > ibResultY)
            {
                sideB = (double)objectLocation.Y - ibResultY;
            }
            else {
                sideB = (double)(-1)*(objectLocation.Y - ibResultY);
            }
            hypotenuse = Math.Sqrt((sideC * sideC) + (sideB * sideB));

            // cosDegree is the cosinus of the missing degree
            double cosDegree = (Math.Pow(hypotenuse, 2) + Math.Pow(sideC, 2) - Math.Pow(sideB, 2)) / (2 * hypotenuse * sideC);
            newDegree = Math.Acos(cosDegree); // degree in radiants
            newDegree = RadianToDegree(newDegree); // degree in degrees
            
            SetNewDegree( Math.Floor( newDegree)); // set degree info
            return newDegree;
        }

        public void setDegree(double oldDegree) {
            degree = oldDegree;
        }
        public double getDegree() {
            return degree;
        }

        public void SetNewDegree( double degree) {
            newDegree = degree;
        }
        
        public double getNewDegree() {
            return newDegree;
        }

        // lastCalculatedDegree = SetNewDegree(double degree);
        // if IsObjectInCenter==false, means that object is moving to another side create triangle
        // servonun current position degerine ( sağa ya da sola dönecek olmasına göre ) 
        // rotation degree eklenecek ya da çıkarılacak
        public double CalculateRotationDegree(double degree, double newDegree)
        {
            if (newDegree > degree)
            {
                // goes to top at rotationDegree 
                rotationDegree = Math.Floor(newDegree - degree);
                //rotationDegree = double.Parse(rotationDegree.ToString("#.0"));
                //if (degree > rotationDegree)
                //{
                //    rotationDegree = Math.Floor(degree - rotationDegree);
                //   // rotationDegree = double.Parse(rotationDegree.ToString("#.0"));
                //}
                //else {
                //    rotationDegree = Math.Floor(rotationDegree - degree);
                //   // rotationDegree = double.Parse(rotationDegree.ToString("#.0"));
                //}
                return rotationDegree;
            }
            else if (newDegree < degree)
            {
                // goes to bottom at rotationDegree 
                rotationDegree = Math.Floor(degree - newDegree);

                //if (degree > rotationDegree)
                //{
                //    rotationDegree = Math.Floor(degree - rotationDegree);
                //   // rotationDegree = double.Parse(rotationDegree.ToString("#.0"));
                //}
                //else {
                //    rotationDegree = Math.Floor(rotationDegree - degree);
                //    //rotationDegree = double.Parse(rotationDegree.ToString("#.0"));
                //}
                return rotationDegree;
            }
            return 0;

        }

        public void RotateServo() { 
            
        }

        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }
        private double RadianToDegree(double angle)
        {
            return angle * (180 / Math.PI); 
        }




    }
}
