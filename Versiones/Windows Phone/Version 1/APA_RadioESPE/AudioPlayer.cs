using System;
using System.Diagnostics;
using System.Windows;
using Microsoft.Phone.BackgroundAudio;
using System.Collections.Generic;

namespace APA_RadioESPE
{
    public class AudioPlayer : AudioPlayerAgent
    {
        /// <remarks>
        /// del agente en segundo plano pueden compartir el mismo proceso.
        /// Los campos estáticos pueden utilizarse para compartir el estado entre las instancias de AudioPlayer
        /// o para comunicarse con el agente de transmisión por secuencias de audio.
        /// </remarks>

        static int currentTrackNumber = 0;

        static AudioPlayer()
        {
            // Suscribirse al controlador de excepciones administradas
            Deployment.Current.Dispatcher.BeginInvoke(delegate
            {
                Application.Current.UnhandledException += UnhandledException;
            });
        }

        /// Código para ejecutar en excepciones no controladas
        private static void UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                // Se ha producido una excepción no controlada; interrumpir el depurador
                Debugger.Break();
            }
        }

        /// <summary>
        /// Se llama cuando cambia el estado de reproducción, excepto en el caso del estado Error (consulte OnError)
        /// </summary>
        /// <param name="player">El objeto BackgroundAudioPlayer</param>
        /// <param name="track">Pista que se estaba reproduciendo en el momento que cambió el estado de reproducción</param>
        /// <param name="playState">Nuevo estado de reproducción del reproductor</param>
        /// <remarks>
        /// No se pueden cancelar los cambios del estado de reproducción. Estos cambios se desencadenan aunque sea la propia aplicación
        /// la que causa el cambio de estado, suponiendo que la aplicación participe en la devolución de llamada.
        ///
        /// Eventos del estado de reproducción notables:
        /// (a) TrackEnded: se invoca cuando el reproductor no tiene pista actual. El agente se puede establecer en la siguiente pista.
        /// (b) TrackReady: se ha establecido una pista de audio que ahora está preparada para reproducirse.
        ///
        /// Llamar a NotifyComplete() solo una vez, después de que se haya completado la solicitud del agente, incluidas las devoluciones de llamada asincrónicas.
        /// </remarks>
        protected override void OnPlayStateChanged(BackgroundAudioPlayer player, AudioTrack track, PlayState playState)
        {
            switch (playState)
            {
                case PlayState.TrackEnded:
                    player.Track = GetPreviousTrack();
                    break;
                case PlayState.TrackReady:
                    player.Play();
                    break;
                case PlayState.Shutdown:
                    // TODO: Controlar el estado de apagado aquí (por ejemplo, estado de almacenamiento)
                    break;
                case PlayState.Unknown:
                    break;
                case PlayState.Stopped:
                    break;
                case PlayState.Paused:
                    break;
                case PlayState.Playing:
                    break;
                case PlayState.BufferingStarted:
                    break;
                case PlayState.BufferingStopped:
                    break;
                case PlayState.Rewinding:
                    break;
                case PlayState.FastForwarding:
                    break;
            }

            NotifyComplete();
        }

        /// <summary>
        /// Se llama cuando el usuario solicita una acción mediante la interfaz de usuario proporcionada por la aplicación o el sistema
        /// </summary>
        /// <param name="player">El objeto BackgroundAudioPlayer</param>
        /// <param name="track">Pista que se estaba reproduciendo en el momento de la acción del usuario</param>
        /// <param name="action">Acción solicitada por el usuario</param>
        /// <param name="param">Datos asociados a la acción solicitada.
        /// En la versión actual este parámetro sólo se usa con la acción Seek
        /// para indicar la posición solicitada de una pista de audio</param>
        /// <remarks>
        /// Las acciones del usuario no realizan cambios automáticamente en el estado del sistema; el agente es responsable
        /// para llevar a cabo las acciones del usuario si son compatibles.
        ///
        /// Llamar a NotifyComplete() solo una vez, después de que se haya completado la solicitud del agente, incluidas las devoluciones de llamada asincrónicas.
        /// </remarks>
        protected override void OnUserAction(BackgroundAudioPlayer player, AudioTrack track, UserAction action, object param)
        {
            switch (action)
            {
                case UserAction.Play:
                    PlayTrack(player);
                    break;
                case UserAction.Stop:
                    player.Stop();
                    break;
                case UserAction.Pause:
                    player.Pause();
                    break;
                case UserAction.FastForward:
                    player.FastForward();
                    break;
                case UserAction.Rewind:
                    player.Rewind();
                    break;
                case UserAction.Seek:
                    player.Position = (TimeSpan)param;
                    break;
                case UserAction.SkipNext:
                    //player.Track = GetNextTrack();
                    break;
                case UserAction.SkipPrevious:
                    /*AudioTrack previousTrack = GetPreviousTrack();
                    if (previousTrack != null)
                    {
                        player.Track = previousTrack;
                    }*/
                    break;
            }

            NotifyComplete();
        }

        /// <summary>
        /// Implementa la lógica para obtener la siguiente instancia de AudioTrack.
        /// En una lista de reproducción, el origen puede ser un archivo, una solicitud web, etc.
        /// </summary>
        /// <remarks>
        /// El URI de AudioTrack determina el origen, que puede ser:
        /// (a) Archivo de almacenamiento aislado (URI relativo, representa la ruta de acceso en el almacenamiento aislado)
        /// (b) Dirección URL HTTP (URI absoluto)
        /// (c) MediaStreamSource (null)
        /// </remarks>
        /// <returns>una instancia de AudioTrack, o null si se ha completado la reproducción</returns>
        private AudioTrack GetNextTrack()
        {
            // TODO: agregar lógica para obtener la siguiente pista de audio

            AudioTrack track = null;

            // especificar la pista

            return track;
        }

        /// <summary>
        /// Implementa la lógica para obtener la instancia anterior de AudioTrack.
        /// </summary>
        /// <remarks>
        /// El URI de AudioTrack determina el origen, que puede ser:
        /// (a) Archivo de almacenamiento aislado (URI relativo, representa la ruta de acceso en el almacenamiento aislado)
        /// (b) Dirección URL HTTP (URI absoluto)
        /// (c) MediaStreamSource (null)
        /// </remarks>
        /// <returns>una instancia de AudioTrack, o null si la pista anterior no se permite</returns>
        private AudioTrack GetPreviousTrack()
        {
            // TODO: agregar lógica para obtener la pista de audio anterior

            AudioTrack track = null;

            // especificar la pista

            return track;
        }

        /// <summary>
        /// Se llama siempre que se produce un error con el estado de reproducción, por ejemplo, si AudioTrack no se descarga correctamente
        /// </summary>
        /// <param name="player">El objeto BackgroundAudioPlayer</param>
        /// <param name="track">Pista donde se produjo el error</param>
        /// <param name="error">Error producido</param>
        /// <param name="isFatal">Si es True, la reproducción no podrá continuar y se detendrá la reproducción de la pista</param>
        /// <remarks>
        /// No existen garantías de que se llame a este método en todos los casos. Por ejemplo, si las instancias de AudioPlayer
        /// tiene una excepción no controlada, no se incluirá en ninguna devolución de llamada para que administre sus propios errores.
        /// </remarks>
        protected override void OnError(BackgroundAudioPlayer player, AudioTrack track, Exception error, bool isFatal)
        {
            if (isFatal)
            {
                Abort();
            }
            else
            {
                NotifyComplete();
            }

        }

        /// <summary>
        /// Se llama cuando se va a cancelar la solicitud del agente
        /// </summary>
        /// <remarks>
        /// Una vez cancelada la solicitud, el agente obtiene 5 segundos para finalizar el trabajo,
        /// mediante una llamada a NotifyComplete()/Abort().
        /// </remarks>
        protected override void OnCancel()
        { }

        private static List<AudioTrack> _playList = new List<AudioTrack>
        {
            new AudioTrack(new Uri("http://radio.espe.edu.ec/radioeskpe", UriKind.Absolute),
                "Radio ESPE",
                "ESKPE",
                "Windows Phone-Radio ESPE",
                null)
        };

        private void PlayTrack(BackgroundAudioPlayer player)
        {
            if((player.Track == null) || (player.Track.Title != _playList[currentTrackNumber].Title))
            {
                player.Track = _playList[currentTrackNumber];
            }

            if ((player.Track != null) && (player.PlayerState != PlayState.Playing))
            {
                player.Play();
            }
        }
    }
}