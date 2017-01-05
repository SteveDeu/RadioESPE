package ufa.desarrollo.radioespe;

import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;

/**
 * Created by Steven on 18/12/2016.
 */

public class Peticiones extends Fragment {
    View rootView;
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {


        rootView = inflater.inflate(R.layout.activity_peticiones, container, false);
        Button enviarm = (Button) rootView.findViewById(R.id.btnEnviarMail);
        EditText etMensaje = (EditText) rootView.findViewById(R.id.et_EmailMensaje);
        etMensaje.setHintTextColor(getResources().getColor(R.color.PISTACHO));
        etMensaje.setTextColor(getResources().getColor(R.color.NEGRO));

        enviarm.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                //enviar();
            }
        });

        enviarm.setTextColor(Color.parseColor("#FFFFFFFF"));
        enviarm.setBackgroundColor(Color.parseColor("#FF244D27"));
        return rootView;
    }
    public void enviar(){
        EditText etMensaje = (EditText) rootView.findViewById(R.id.et_EmailMensaje);
        etMensaje.setHintTextColor(getResources().getColor(R.color.NEGRO));
        String subject = "Peticiones";
        String message = etMensaje.getText().toString();

        Intent email = new Intent(Intent.ACTION_SEND);
        email.putExtra(Intent.EXTRA_SUBJECT, subject);
        email.putExtra(Intent.EXTRA_TEXT, message);
        email.putExtra(Intent.EXTRA_EMAIL, new String[] { "radioeskpe@espe.edu.ec" });
        //email.setData(Uri.parse("radioeskpe@espe.edu.ec"));
        email.setType("message/rfc822");

        startActivity(Intent.createChooser(email, "Seleciona un cliente de correo"));
        etMensaje.setText("");

    }
}
