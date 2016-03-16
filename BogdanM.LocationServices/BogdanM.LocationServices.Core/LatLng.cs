namespace BogdanM.LocationServices.Core
{
    public class LatLng
    {
        public readonly decimal Lat;
        public readonly decimal Lng;

        public LatLng(decimal lat, decimal lng)
        {
            this.Lat = lat;
            this.Lng = lng;
        }

        public static LatLng operator -(LatLng a, LatLng b)
        {
            return new LatLng(b.Lat - a.Lat, b.Lng - a.Lng);
        }
        public static LatLng operator +(LatLng a, LatLng b)
        {
            return new LatLng(a.Lat + b.Lat, a.Lng + b.Lng);
        }
        public static LatLng operator *(LatLng a, decimal d)
        {
            return new LatLng(a.Lat * d, a.Lng * d);
        }

        public override string ToString()
        {
            return $"[{this.Lat:###.###############}, {this.Lng:###.###############}]";
        }
    }
}