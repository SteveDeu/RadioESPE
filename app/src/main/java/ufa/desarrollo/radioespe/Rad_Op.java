package ufa.desarrollo.radioespe;

import android.app.Activity;
import android.media.MediaPlayer;

import java.io.IOException;

/**
 * Created by Steven on 18/12/2016.
 */

public class Rad_Op extends Activity {


    private MediaPlayer mp = new MediaPlayer();

    public void abrirred(){
        try {
            mp.setDataSource("http://radio.espe.edu.ec/radioeskpe");
            mp.prepare();
            mp.start();


        } catch (IllegalArgumentException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        } catch (SecurityException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        } catch (IllegalStateException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        } catch (IOException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }
    }

    public void cerrarred(){
        try {
            mp.stop();
            mp.reset();


        } catch (IllegalArgumentException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        } catch (SecurityException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        } catch (IllegalStateException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }
    }

}