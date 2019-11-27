using System;
using System.Collections.Generic;
using System.Text;

namespace EticaGame.Models
{
    class TFAnserCard<CType> : QCard<CType>
    {
        bool RespuestaCorrecta;
        public TFAnserCard(string pregunta, bool respuesta, CType tema) : base(pregunta, tema)
        {
            RespuestaCorrecta = respuesta;
        }

        public bool IsRight(bool respuestaUsr)
        {
            return (respuestaUsr == RespuestaCorrecta);
        }
    }
}
