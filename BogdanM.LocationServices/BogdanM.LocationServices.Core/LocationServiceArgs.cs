using System;

namespace BogdanM.LocationServices.Core
{
    /// <summary>
    /// Implements IDisposable only for allowing usage with Owin IdentityFactoryOptions creation.
    /// </summary>
    public class LocationServiceArgs : IDisposable
    {
        /// <summary>
        /// Api Key for allowing usage of the service.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Country and city code.
        /// Eg: for Bucharest, Romania it's "ro-bucharest".
        /// </summary>
        public string Cccode { get; set; }

        /// <summary>
        /// Base format for the url for the geocoding operation.
        /// </summary>
        public string BaseGeocodeUrl { get; set; }

        /// <summary>
        /// Base format for the url for the reverse geocoding operation.
        /// </summary>
        public string BaseGeocodeReverseUrl  { get; set; }

        /// <summary>
        /// Base format for the url for the routing operation.
        /// </summary>
        public string BaseRouteUrl { get; set; }

        /// <summary>
        /// Dummy implementation for allowing usage with Owin IdentityFactoryOptions creation.
        /// </summary>
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}