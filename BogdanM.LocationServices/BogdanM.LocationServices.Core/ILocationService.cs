using System;
using System.Threading.Tasks;

namespace BogdanM.LocationServices.Core
{
    /// <summary>
    /// Contract for basic location services operations like geocoding, reverse geocoding, routing and distance.
    /// Implements IDisposable only for allowing usage with Owin IdentityFactoryOptions creation.
    /// </summary>
    public interface ILocationService : IDisposable
    {
        /// <summary>
        /// Converts a human-readable address into geographic coordinates.
        /// </summary>
        /// <param name="address">The input address (street name and no, city and country) as an <see cref="Address"/> object.</param>
        /// <returns>The latitude and longitude of the given address as a <see cref="LatLng"/> structure.</returns>
        LatLng Geocode(Address address);

        /// <summary>
        /// Async operation for converting a human-readable address into geographic coordinates.
        /// </summary>
        /// <param name="address">The input address (street name and no, city and country) as an <see cref="Address"/> object.</param>
        /// <returns>The latitude and longitude of the given address as a <see cref="Task" /> object.</returns>
        Task<LatLng> GeocodeAsync(Address address);

        /// <summary>
        /// Converts geographic coordinates into a human-readable address.
        /// </summary>
        /// <param name="point">The input latitude and longitude as a <see cref="LatLng"/> structure.</param>
        /// <returns>The address (street name and no, city and country) as an <see cref="Address"/> object.</returns>
        Address ReverseGeocode(LatLng point);

        /// <summary>
        /// Async operation for converting geographic coordinates into a human-readable address.
        /// </summary>
        /// <param name="point">The input latitude and longitude as a <see cref="LatLng"/> structure.</param>
        /// <returns>The address (street name and no, city and country) as a <see cref="Task" /> object.</returns>
        Task<Address> ReverseGeocodeAsync(LatLng point);

        /// <summary>
        /// Gets the distance in meters between two geographic points.
        /// </summary>
        /// <param name="from">The first geographic point as a <see cref="LatLng"/> structure.</param>
        /// <param name="to">The second geographic point as a <see cref="LatLng"/> structure.</param>
        /// <returns>The distance in meters as an integer.</returns>
        int GetDistance(LatLng @from, LatLng to);

        /// <summary>
        /// Async operation for getting the distance in meters between two geographic points.
        /// </summary>
        /// <param name="from">The first geographic point as a <see cref="LatLng"/> structure.</param>
        /// <param name="to">The second geographic point as a <see cref="LatLng"/> structure.</param>
        /// <returns>The distance in meters as an <see cref="Task"/> object.</returns>
        Task<int> GetDistanceAsync(LatLng @from, LatLng to);

        /// <summary>
        /// Returns the route between two geographic points.
        /// </summary>
        /// <param name="from">The first geographic point as a <see cref="LatLng"/> structure.</param>
        /// <param name="to">The second geographic point as a <see cref="LatLng"/> structure.</param>
        /// <returns>An ordered array of <see cref="LatLng"/> structures represeting the route.</returns>
        LatLng[] GetRoute(LatLng @from, LatLng to);

        /// <summary>
        /// Async operation for getting the route between two geographic points.
        /// </summary>
        /// <param name="from">The first geographic point as a <see cref="LatLng"/> structure.</param>
        /// <param name="to">The second geographic point as a <see cref="LatLng"/> structure.</param>
        /// <returns>An ordered array of <see cref="LatLng"/> structures represeting the route in the result of a <see cref="Task"/> object.</returns>
        Task<LatLng[]> GetRouteAsync(LatLng @from, LatLng to);
    }
}