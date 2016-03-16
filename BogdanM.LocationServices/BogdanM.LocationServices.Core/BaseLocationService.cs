using System;
using System.Threading.Tasks;
using BogdanM.LocationServices.Core.Infrastructure;

namespace BogdanM.LocationServices.Core
{
    public abstract class BaseLocationService : ILocationService
    {
        protected readonly string ApiKey;
        protected readonly string BaseGeocodeUrl;
        protected readonly string BaseGeocodeReverseUrl;
        protected readonly string BaseRouteUrl;

        /// <summary>
        /// Default constructor for a LocationService implementation.
        /// </summary>
        /// <param name="apiKey">Api Key for allowing usage of the service.</param>
        /// <param name="baseGeocodeUrl">Base format for the url for the geocoding operation.</param>
        /// <param name="baseGeocodeReverseUrl">Base format for the url for the reverse geocoding operation.</param>
        /// <param name="baseRouteUrl">Base format for the url for the routing operation.</param>
        protected BaseLocationService(string apiKey, string baseGeocodeUrl, string baseGeocodeReverseUrl, string baseRouteUrl)
        {
            if (string.IsNullOrEmpty(apiKey))
                throw new ArgumentNullException(nameof(apiKey));

            if (string.IsNullOrEmpty(baseGeocodeUrl))
                throw new ArgumentNullException(nameof(baseGeocodeUrl));

            if (string.IsNullOrEmpty(baseGeocodeReverseUrl))
                throw new ArgumentNullException(nameof(baseGeocodeReverseUrl));

            if (string.IsNullOrEmpty(baseRouteUrl))
                throw new ArgumentNullException(nameof(baseRouteUrl));

            this.ApiKey = apiKey;
            this.BaseGeocodeUrl = baseGeocodeUrl;
            this.BaseGeocodeReverseUrl = baseGeocodeReverseUrl;
            this.BaseRouteUrl = baseRouteUrl;
        }

        /// <summary>
        /// Converts a human-readable address into geographic coordinates.
        /// </summary>
        /// <param name="address">The input address (street name and no, city and country) as an <see cref="Address"/> object.</param>
        /// <returns>The latitude and longitude of the given address as a <see cref="LatLng"/> structure.</returns>
        public abstract LatLng Geocode(Address address);

        /// <summary>
        /// Async operation for converting a human-readable address into geographic coordinates.
        /// </summary>
        /// <param name="address">The input address (street name and no, city and country) as an <see cref="Address"/> object.</param>
        /// <returns>The latitude and longitude of the given address as a <see cref="Task" /> object.</returns>
        public abstract Task<LatLng> GeocodeAsync(Address address);

        /// <summary>
        /// Gets the distance in meters between two geographic points.
        /// </summary>
        /// <param name="from">The first geographic point as a <see cref="LatLng"/> structure.</param>
        /// <param name="to">The second geographic point as a <see cref="LatLng"/> structure.</param>
        /// <returns>The distance in meters as an integer.</returns>
        public abstract int GetDistance(LatLng from, LatLng to);

        /// <summary>
        /// Async operation for getting the distance in meters between two geographic points.
        /// </summary>
        /// <param name="from">The first geographic point as a <see cref="LatLng"/> structure.</param>
        /// <param name="to">The second geographic point as a <see cref="LatLng"/> structure.</param>
        /// <returns>The distance in meters as an <see cref="Task"/> object.</returns>
        public abstract Task<int> GetDistanceAsync(LatLng from, LatLng to);

        /// <summary>
        /// Returns the route between two geographic points.
        /// </summary>
        /// <param name="from">The first geographic point as a <see cref="LatLng"/> structure.</param>
        /// <param name="to">The second geographic point as a <see cref="LatLng"/> structure.</param>
        /// <returns>An ordered array of <see cref="LatLng"/> structures represeting the route.</returns>
        public abstract LatLng[] GetRoute(LatLng from, LatLng to);

        /// <summary>
        /// Async operation for getting the route between two geographic points.
        /// </summary>
        /// <param name="from">The first geographic point as a <see cref="LatLng"/> structure.</param>
        /// <param name="to">The second geographic point as a <see cref="LatLng"/> structure.</param>
        /// <returns>An ordered array of <see cref="LatLng"/> structures represeting the route in the result of a <see cref="Task"/> object.</returns>
        public abstract Task<LatLng[]> GetRouteAsync(LatLng from, LatLng to);

        /// <summary>
        /// Converts geographic coordinates into a human-readable address.
        /// </summary>
        /// <param name="point">The input latitude and longitude as a <see cref="LatLng"/> structure.</param>
        /// <returns>The address (street name and no, city and country) as an <see cref="Address"/> object.</returns>
        public abstract Address ReverseGeocode(LatLng point);

        /// <summary>
        /// Async operation for converting geographic coordinates into a human-readable address.
        /// </summary>
        /// <param name="point">The input latitude and longitude as a <see cref="LatLng"/> structure.</param>
        /// <returns>The address (street name and no, city and country) as a <see cref="Task" /> object.</returns>
        public abstract Task<Address> ReverseGeocodeAsync(LatLng point);

        /// <summary>
        /// Returns true if the given point is inside the given geofence and false otherwise.
        /// </summary>
        /// <param name="point">The input latitude and longitude as a <see cref="LatLng"/> structure.</param>
        /// <param name="geoFence">The geofence represented by an array of <see cref="LatLng"/> structurs.</param>
        /// <returns>True of false regarding if the given point is inside the given geofence.</returns>
        public bool IsInside(LatLng point, LatLng[] geoFence)
        {
            return geoFence.IsPointInside(point);
        }
    }
}