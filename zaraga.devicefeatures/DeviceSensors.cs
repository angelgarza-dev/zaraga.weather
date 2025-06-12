using System;
using System.Diagnostics;

namespace zaraga.devicefeatures
{
    public class DeviceSensors
    {
        private CancellationTokenSource _locationCancelTokenSource = new CancellationTokenSource();
        private bool _isGettingLocation = false;


        #region Permission

        /// <summary>
        /// Obtiene el estatus de un permiso.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="permission"></param>
        /// <returns></returns>
        public async Task<PermissionStatus> CheckPermissionStatus<T>(T permission) where T : Microsoft.Maui.ApplicationModel.Permissions.BasePermission
        {
            return await permission.CheckStatusAsync();
        }

        /// <summary>
        /// Valida si la aplicacion tiene un permiso especifico, de lo contrario intenta obtener el permiso
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="permission"></param>
        /// <returns></returns>
        public async Task<PermissionStatus> CheckAndRequestPermissionAsync<T>(T permission) where T : Microsoft.Maui.ApplicationModel.Permissions.BasePermission
        {
            try
            {
                var status = await CheckPermissionStatus(permission);
                if (status != PermissionStatus.Granted)
                {
                    status = await permission.RequestAsync();
                }

                return status;
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine($"Error al obtener el permiso: {ex.Message}");
#endif
                return PermissionStatus.Denied;
            }
        }

        #endregion

        #region Geolocation

        /// <summary>
        /// Obtiene el permiso de geolocalizacion.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> GetLocationPermisse()
        {
            try
            {
                PermissionStatus locationPermission = await CheckAndRequestPermissionAsync(new Permissions.LocationWhenInUse());
                if (locationPermission != PermissionStatus.Granted)
                {
                    locationPermission = await CheckAndRequestPermissionAsync(new Permissions.LocationWhenInUse());
                }

                return locationPermission == PermissionStatus.Granted;
            }
            catch (FeatureNotSupportedException fnsEx)
            {
#if DEBUG
                Debug.WriteLine($"La Geolocalizacion no es soportada por el dispositivo: {fnsEx.Message}");
#endif
                return false;
            }
            catch (FeatureNotEnabledException fneEx)
            {
#if DEBUG
                Debug.WriteLine($"La Geolocalizacion se encuentra desactivada: {fneEx.Message}");
#endif
                return false;
            }
            catch (PermissionException pEx)
            {
#if DEBUG
                Debug.WriteLine($"La Geolocalizacion no tiene el permiso necesario: {pEx.Message}");
#endif
                return false;
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine($"Error al obtener el permiso de geolocalizacion: {ex.Message}");
#endif
                return false;
            }
        }

        /// <summary>
        /// Obtiene la ubicacion actual del dispositivo.
        /// </summary>
        /// <returns></returns>
        public async Task<Location?> GetCurrentLocation()
        {
            try
            {
                if (_isGettingLocation)
                {
                    _locationCancelTokenSource.Cancel();
                }

                _isGettingLocation = true;
                _locationCancelTokenSource = new CancellationTokenSource();
                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.High, TimeSpan.FromSeconds(10));
                Location? location = await Geolocation.Default.GetLocationAsync(request, _locationCancelTokenSource.Token);

                if (location != null)
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                else
                    location = await Geolocation.Default.GetLastKnownLocationAsync();

                return location;
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine($"Error al obtener la geolocalizacion: {ex.Message}");
#endif
                throw;
            }
            finally
            {
                _isGettingLocation = false;
                _locationCancelTokenSource?.Dispose();
            }
        }

        #endregion


    }
}
