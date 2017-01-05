package ufa.desarrollo.radioespe;

import android.graphics.Color;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;

/**
 * Created by Steven on 18/12/2016.
 */

public class RadioOnLine extends Fragment {

    View rootView;


    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        rootView = inflater.inflate(R.layout.radio, container, false);
        final Button boton_encen = (Button) rootView.findViewById(R.id.btn_encender);
        final Button boton_apag = (Button) rootView.findViewById(R.id.btn_apagar);
        final TextView textoconect = (TextView) rootView.findViewById(R.id.txt_conexion);

        textoconect.setText("RADIO APAGADA");
        boton_encen.setTextColor(Color.parseColor("#FFFFFFFF"));
        boton_encen.setBackgroundColor(Color.parseColor("#FF244D27"));
        boton_apag.setBackgroundColor(Color.parseColor("#FFE2E0E0"));
        boton_apag.setTextColor(Color.parseColor("#FF989898"));
        textoconect.setTextColor(Color.parseColor("#FFB01515"));
        boton_apag.setEnabled(false);

        final Rad_Op ab = new Rad_Op();


        boton_encen.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                boton_encen.setEnabled(false);
                boton_apag.setEnabled(false);
                ab.abrirred();
                boton_encen.setBackgroundColor(Color.parseColor("#FFE2E0E0"));
                boton_encen.setTextColor(Color.parseColor("#FF989898"));
                boton_encen.setText("Sonando");
                textoconect.setText("RADIO ENCENDIDA");
                textoconect.setTextColor(Color.parseColor("#FF46AA45"));
                boton_apag.setTextColor(Color.parseColor("#FFFFFFFF"));
                boton_apag.setBackgroundColor(Color.parseColor("#FF244D27"));
                boton_apag.setEnabled(true);

            }
        });


        boton_apag.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                boton_encen.setEnabled(true);
                boton_encen.setTextColor(Color.parseColor("#FFFFFFFF"));
                boton_encen.setBackgroundColor(Color.parseColor("#FF244D27"));
                boton_apag.setEnabled(false);
                ab.cerrarred();
                boton_encen.setText("Encender");
                boton_apag.setBackgroundColor(Color.parseColor("#FFE2E0E0"));
                boton_apag.setTextColor(Color.parseColor("#FF989898"));
                textoconect.setText("RADIO APAGADA");
                textoconect.setTextColor(Color.parseColor("#FFB01515"));
            }
        });
        return rootView;
    }


}
