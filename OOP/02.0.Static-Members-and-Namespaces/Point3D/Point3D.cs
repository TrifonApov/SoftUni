namespace Point3D
{
    public class Point3D
    {
        static readonly double startPoint = 0;
        private double pointX;
        private double pointY;
        private double pointZ;
        /// <summary>
        /// Create new point with cordinates x=0,y=0,z=0
        /// </summary>
        public Point3D()
        {
            this.PointX = startPoint;
            this.PointY = startPoint;
            this.PointZ = startPoint;
        }
        /// <summary>
        /// Create new point with given coordinates for x, y and z
        /// </summary>
        public Point3D(double x, double y, double z)
        {
            this.PointX = x;
            this.PointY = y;
            this.PointZ = z;
        }

        public double PointX
        {
            get { return this.pointX; }
            set { this.pointX = value; }
        }

        public double PointY
        {
            get { return this.pointY; }
            set { this.pointY = value; }
        }

        public double PointZ
        {
            get { return this.pointZ; }
            set { this.pointZ = value; }
        }

        /// <summary>
        /// Return double array starting point x, y, z equals 0
        /// </summary>
        public static double[] StartPoint
        {
            get
            {
                return new [] {0d,0d,0d};
            }
        }

        public override string ToString()
        {
            return string.Format("X = {0}; Y = {1}; Z = {2}", this.PointX, this.PointY, this.PointZ);
        }
    }
}