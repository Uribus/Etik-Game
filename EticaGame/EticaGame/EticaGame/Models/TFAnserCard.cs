using System;
using System.Collections.Generic;
using System.Text;

namespace EticaGame.Models
{
    public class TFAnserCard : QCard
    {
        bool RespuestaCorrecta;
        public TFAnserCard(string pregunta, bool respuesta, string tema) : base(pregunta, tema)
        {
            RespuestaCorrecta = respuesta;
        }

        public bool IsRight(bool respuestaUsr)
        {
            return (respuestaUsr == RespuestaCorrecta);
        }
    }
}
