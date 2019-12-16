using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using EticaGame.Models;
using Xamarin.Forms;
using Rg.Plugins.Popup.Services;
using EticaGame.Views;
using EticaGame.Views.CardViews;
using System.ComponentModel;

namespace EticaGame.ViewModels
{
    public class GameViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }
        enum CType { Brecha, SLibre, ProdDatos, Privacidad, Facts }
        //enum Action { Turno, Tira, Debate, Pierde, Roba }

        List<QCard> CartasGenero = new List<QCard>();
        List<QCard> CartasSoftware = new List<QCard>();
        List<QCard> CartasProteccion = new List<QCard>();
        List<QCard> CartasPrivacidad = new List<QCard>();
        List<QCard> CartasFacts = new List<QCard>();
        //cards that have appeared already in the game
        List<QCard> CartasUsadas = new List<QCard>();
        //action cards
        List<ACard> CartasEspeciales = new List<ACard>();
        public ObservableCollection<Team> Equipos { get; private set; } = new ObservableCollection<Team>();
        //bool Start=false;
        int NTeams;
        int TurnoTeam;
        string turno;
        string usrAns;

        public GameViewModel(int teams, INavigation navigation)
        {
            this.NTeams = teams;

            //initialize and fill all the lists
            CreaEquipos(teams);
            LlenarListaBrecha("Brecha");
            LlenarListaSoftware("Software");
            LlenarListaProteccion("Proteccion");
            LlenarListaPrivacidad("Privacidad");
            LlenarListaFact("Facts");
            LLenarListaEspeciales();
            TurnoTeam = 0;
            ActualizarTurno();
            this.Navigation = navigation;
        }

        void ActualizarTurno()
        {
            if(TurnoTeam < NTeams)
            {
                TurnoTeam += 1;   
            }
            else 
            {
                TurnoTeam = 1; 
            }
            turno = "Equipo" + TurnoTeam.ToString();
        }

        void CreaEquipos(int equipos)
        {
            for(int i = 0; i < equipos; i++)
            {
                Equipos.Add(new Team(i + 1));
            }
        }

        //gender questions
        void LlenarListaBrecha(string tipo)
        {
            CartasGenero.Add(new QCard("¿Qué término se suele emplear para hacer referencia al desconocimiento o a la falta de educación en el uso de las herramientas y recursos de la tecnología digital?", tipo, "", "#", "", "", "Analfabetismo digital"));
            CartasGenero.Add(new QCard("¿Cómo se denominan los procesos o mecanismos psicológicos que distorsionan nuestro juicio racional y son la raíz de algunas actitudes discriminatorias?", tipo, "", "#", "", "", "Sesgos cognitivos"));
            CartasGenero.Add(new QCard("¿Qué significa el concepto “techo de cristal” en los estudios de brecha de género?", tipo, "", "#", "", "", "Limitación en el ascenso laboral o en una jerarquía"));
            CartasGenero.Add(new QCard("¿Qué concepto se utilizó como tema principal en una de las conferencias para analizar y referirse a la perspectiva, punto de vista o mentalidad del hombre?", tipo, "", "#", "", "", "Subjetividad masculina"));
            CartasGenero.Add(new QCard("En estudios de materia de género, ¿cómo se denominan los perfiles predeterminados de género o generalizaciones sociales injustas de los comportamientos y actitudes de cada género?", tipo, "", "#", "", "", "Estereotipos de género"));
            CartasGenero.Add(new QCard("En los inicios de la informática las mujeres se dedicaban casi exclusivamente al diseño del software.", tipo, "Verdadero", "Falso", "", "", "Verdadero"));
            CartasGenero.Add(new QCard("La brecha de género en ciencias de la computación se ha reducido en los últimos 30 años.", tipo, "Verdadero", "Falso", "", "", "Falso"));
            CartasGenero.Add(new QCard("La brecha digital se mide principalmente analizando parámetros relacionados con la conectividad y el acceso a las TICs.", tipo, "Verdadero", "Falso", "", "", "Verdadero"));
            CartasGenero.Add(new QCard("La brecha digital se define como la brecha causada por las desigualdades de género reflejadas en el ámbito digital.", tipo, "Verdadero", "Falso", "", "", "Falso"));
            CartasGenero.Add(new QCard("Según datos del Índice de la Economía y la Sociedad Digitales (DESA) del año 2017, casi la mitad de los europeos (44 %) no posee todavía capacidades digitales básicas, como usar el correo electrónico o las herramientas de edición, o instalar nuevos dispositivos.", tipo, "Verdadero", "Falso", "", "", "Verdadero"));
            CartasGenero.Add(new QCard("En los inicios de la informática las mujeres se dedicaban casi exclusivamente al diseño del software", tipo, "Verdadero", "Falso", "", "", "Verdadero"));
            CartasGenero.Add(new QCard("¿Quién se convirtió en la primera mujer ganadora del premio Turing?", tipo, "Betty Snyder", "Ada Lovelace", "Barbara Liskov", "Frances Elizabeth Allen", "Frances Elizabeth Allen"));
            CartasGenero.Add(new QCard("¿Qué opción NO es uno de los 3 tipos principales de brecha de género digital que se mencionaron en la conferencia “Subjetividad masculina en la era de las TICs”?", tipo, "Acceso a la tecnología", "Intensidad y pautas de uso", "Formación y recursos digitales", "Usos avanzados y dispositivos de acceso a Internet", "Formación y recursos digitales"));
            CartasGenero.Add(new QCard("¿Qué mujer desarrolló el primer compilador para un lenguaje de programación, el compilador conocido como A-0?", tipo, "Grace Hopper", "Jean E. Sammet", "Barbara Liskov", "Margaret Hamilton", "Grace Hopper"));
            CartasGenero.Add(new QCard("Según los datos oficiales publicados por el Ministerio de Educación correspondientes al curso 2016-2017, ¿qué porcentaje de mujeres estudiaba informática en la universidad respecto al total de los estudiantes de dicho grado?", tipo, "12,1 %", "16,7 %", "20,4 %", "25,6 %", "12,1 %"));
            CartasGenero.Add(new QCard("¿Qué mujer es considerada la primera persona que utilizó en casa un ordenador personal o PC?", tipo, "Karen Spärck Jones", "Mary Allen Wilkes", "Jean E. Sammet", "Carol Shaw", "Mary Allen Wilkes"));
            CartasGenero.Add(new QCard("¿Qué otra mujer colaboró con sus compañeras Frances Bilas, Marlyn Meltzer, Betty Snyder, Betty Jean en el desarrollo de la computadora ENIAC?", tipo, "Susan Kare", "Carol Shaw", "Ruth Lichterman", "Margaret Hamilton", "Ruth Lichterman"));
            CartasGenero.Add(new QCard("¿Qué famosa creadora de software e ingeniera de redes es conocida como “la madre de Internet” por desarrollar el protocolo STP (Spanning Tree Protocol)?", tipo, "Sally Floyd", "Joan Clarke", "Susan Kare", "Radia Perlman", "Radia Perlman")); 
            CartasGenero.Add(new QCard("¿Quién se convirtió en la primera mujer en ganar la medalla John Von Neumann?", tipo, "Susan Kare", "Karen Spärck Jones", "Barbara Liskov", "Margaret Hamilton", "Barbara Liskov"));
            CartasGenero.Add(new QCard("Según los datos del Instituto Nacional de Estadística correspondientes al año 2017, ¿qué tasa de mujeres por cada mil habitantes con edades comprendidas entre 20 y 29 años se graduó en carreras de ciencias, matemáticas, ingeniería, industria y construcción?", tipo, "9,3 ‰", "13,1 ‰", "17,2 ‰", "20,5 ‰", "13,1 ‰")); 
            CartasGenero.Add(new QCard("¿Qué famosa actriz de Hollywood fue también la inventora de la primera versión del espectro ensanchado, una forma temprana de espectro de propagación en radiodifusión que se considera una técnica precursora de tecnologías como el Wifi o Bluetooth?", tipo, "Joanne Woodward", "Ruth Elizabeth “Bette” Davis", "Katharine Hepburn", "Hedy Lamarr", "Hedy Lamarr"));
            CartasGenero.Add(new QCard("Debate", tipo, "¿Qué medidas serían más efectivas para reducir la brecha de género en el ámbito de la informática?", "", "", "", ""));
            CartasGenero.Add(new QCard("Debate", tipo, "¿Qué obstáculos o desafíos pensáis que en la actualidad son las causas fundamentales de la brecha de género y de la brecha digital? ¿Opináis que dichos obstáculos son principalmente históricos, económicos, políticos, sociales, culturales, educativos o de otra índole?", "", "", "", ""));
            CartasGenero.Add(new QCard("Debate", tipo, "¿Cómo podría la inteligencia artificial repercutir en la brecha de género y la brecha digital? ¿Pensáis que su impacto podría ser principalmente positivo o negativo?", "", "", "", ""));
            CartasGenero.Add(new QCard("Debate", tipo, "¿Creéis que los estereotipos de género seguirían existiendo o desaparecerían con el paso del tiempo si en un hipotético futuro o en una realidad virtual todos los humanos nos transformáramos en robots que solamente conservasen nuestros rasgos faciales? ¿Por qué?", "", "", "", ""));

        }
        //FOSS questions
        void LlenarListaSoftware(string tipo)
        {
            CartasSoftware.Add(new QCard("Significado siglas FOSS o en castellano PLiCA.", tipo, "", "#", "", "", "FOSS : Free and Open Source Software, PLiCA: Programas Libres y de Código Abierto"));
            CartasSoftware.Add(new QCard("¿Qué significa “Software libre y de código abierto” o FOSS?", tipo, "", "#", "", "", "Es el software que está licenciado (otorgado o aprobado) de tal manera que los usuarios pueden estudiar, modificar y mejorar su diseño mediante la disponibilidad de su código fuente (nos da libertad para hacer todo el uso, copiar, estudiar, modificar el código fuente libremente)"));
            CartasSoftware.Add(new QCard("¿Qué son los programas libres o a que se refiere?", tipo, "", "#", "", "", "Se refiere a la libertad de los usuarios para ejecutar, copiar, distribuir, estudiar, cambiar y mejorar el software"));
            CartasSoftware.Add(new QCard("¿Qué son los programas de código abierto?", tipo, "", "#", "", "", "Es el software cuyo código fuente y otros derechos que normalmente son exclusivos para quienes poseen los derechos de autor, son publicado bajo una licencia de código abierto o forman parte de dominio público"));
            CartasSoftware.Add(new QCard("Menciona alguno de los cuatro principios o libertades del software libre.", tipo, "", "#", "", "", "La libertad de ejecutar el programa para cualquier propósito, la libertad de estudiar cómo funciona el programa, y cambiarlo para que haga lo que usted quiera, la libertad de redistribuir copias para ayudar a su prójimo. El acceso al código fuente es una condición necesaria para ello, la libertad de distribuir copias de sus versiones modificadas a terceros. Esto le permite ofrecer a toda la comunidad la oportunidad de beneficiarse de las modificaciones. El acceso al código fuente es una condición necesaria para ello"));
            CartasSoftware.Add(new QCard("¿Tiene el mismo significado software libre y software gratuito?", tipo, "Verdadero", "Falso", "", "", "Falso"));
            CartasSoftware.Add(new QCard("Diferencias entre el software libre y gratis", tipo, "", "#", "", "", "libre: se cede el código fuente,  gratis: se permite usar la aplicación o software sin pagar pero no se cede el código fuente"));
            CartasSoftware.Add(new QCard("¿Que surge antes la cultura libre o el software libre?", tipo, "", "#", "", "", "El software libre surgió primero"));
            CartasSoftware.Add(new QCard("¿La cultura libre tiene varios niveles de libertad?", tipo, "Verdadero", "Falso", "", "", "Verdadero"));
            CartasSoftware.Add(new QCard("¿Cuál de los siguientes niveles de libertad son correctos?", tipo, "Dominio público y Creative Commons", "Software libre y Hardware libre", "Todos los anteriores", "", "Todos los anteriores"));
            CartasSoftware.Add(new QCard("¿Quién fue el fundador del software libre y del proyecto GNU?", tipo, "Linus Torvalds", "Lawrence Lessig", "Richard Stallman", "Marc Ewing", "Richard Stallman"));
            CartasSoftware.Add(new QCard("Nombra tres de los proyectos de software libre o código abierto más grandes o conocidos.", tipo, "", "#", "", "", "GNU, Linux, Red Hat, Mozilla, Apache, KDE, Gimp, GNOME, NOVELL (OpenSUSE), NotePad++, OpenOffice"));
            CartasSoftware.Add(new QCard("¿Cual de los siguiente proyectos no es de software libre?", tipo, "the GIMP", "Apache", "GNU", "Ninguno de los anteriores", "Ninguno de los anteriores"));
            CartasSoftware.Add(new QCard("¿Cuál de los siguientes proyectos no es de código abierto?", tipo, "Mozilla Firefox", "OpenOffice", "Docker", "Ninguno de los anteriores", "Ninguno de los anteriores"));
            CartasSoftware.Add(new QCard("¿La protección legal del software se realiza mediante los “derechos de autor” o “patente de invención” ?", tipo, "", "#", "", "", "La protección de software se realiza mediante el derecho de autor"));
            CartasSoftware.Add(new QCard("¿Licencias que existen en el software libre y código abierto?", tipo, "", "#", "", "", "GPL (General Public Licences) – obliga a compartir igual, BSD (Berkeley Software Distribution) – no obliga a compartir igual, CC (Creative Commons) - libre uso y distribución, CopyLeft"));
            CartasSoftware.Add(new QCard("¿Qué es el Hardware libre?", tipo, "", "#", "", "", "Es todo dispositivo de hardware cuyas especificaciones y diagramas esquemáticos son de acceso público"));
            CartasSoftware.Add(new QCard("¿Cuál de los siguientes proyectos no es de hardware libre?", tipo, "Arduino", "RepRap", "UltraSparc", "Ninguno de los anteriores", "Ninguno de los anteriores"));
            CartasSoftware.Add(new QCard("¿La licencia de un proyecto o código se debe subir en un fichero único e identificado?", tipo, "", "#", "", "", "Si, se debe subir el un fichero con nombre Licencia"));
            CartasSoftware.Add(new QCard("¿Si un software tiene la licencia de CopyLeft se debe mantener de la misma forma en modificaciones de este?", tipo, "", "#", "", "", "Si, se debe mantener la misma licencia o criterios que sigue esta"));
            CartasSoftware.Add(new QCard("Diferencias entre las licencias de GPL y BSD", tipo, "", "#", "", "", "GPL: obliga a compartir igual, BSD: no obliga a compartir igual"));
            CartasSoftware.Add(new QCard("¿Existen diferentes combinaciones de licencias de Creative Common o que den un significado diferente?", tipo, "Verdadero", "Falso", "", "", "Verdadero"));
            CartasSoftware.Add(new QCard("Debate", tipo, "¿Tiene alguna ventaja o inconvenientes el tener el código fuente de las aplicaciones?", "", "", "", ""));
            CartasSoftware.Add(new QCard("Debate", tipo, "Es mejor el software libre y de código abierto frente al software privado", "", "", "", ""));
            CartasSoftware.Add(new QCard("Debate", tipo, "Existen alternativas de encontrar un software libre que nos sirva y tenga las mismas funcionalidades al igual que el software de pago o privados?", "", "", "", ""));
        }
        //data protection questions
        void LlenarListaProteccion(string tipo)
        {
            CartasProteccion.Add(new QCard("¿Qué significan las siglas RGPD?", tipo, "", "#", "", "", "Reglamento General de Protección de Datos"));
            CartasProteccion.Add(new QCard("¿Qué significan las siglas LOPD?", tipo, "", "#", "", "", "Ley Orgánica de Protección de Datos"));
            CartasProteccion.Add(new QCard("¿Cuándo entró en vigor el RGPD?", tipo, "", "#", "", "", "4 de mayo de 2016"));
            CartasProteccion.Add(new QCard("¿Qué entidad aprobó el RGPD?", tipo, "", "#", "", "", "Union Europea"));
            CartasProteccion.Add(new QCard("¿Cuándo pasó a ser obligatorio el cumplimiento del RGPD?", tipo, "", "#", "", "", "25 de mayo 2018"));
            CartasProteccion.Add(new QCard("¿Dónde se publicó el RGPD?", tipo, "", "#", "", "", "Diario Oficial de la Union Europea"));
            CartasProteccion.Add(new QCard("¿Qué dos países de la UE tienen un considerando en específico para ellos?", tipo, "", "#", "", "", "Dinamarca y Estonia (Ambos comparten el considerando dedicado 151. Parece ser que no pueden imponer multas administrativas (económicas), y hay que pasar para ello por sus respectivos tribunales)"));
            CartasProteccion.Add(new QCard("¿Cuántos artículos contiene el RGPD?", tipo, "", "#", "", "", "Contiene 99 articulos"));
            CartasProteccion.Add(new QCard("El tratamiento de datos personales debe estar concebido para servir a la humanidad", tipo, "Verdadero", "Falso", "", "", "Verdadero"));
            CartasProteccion.Add(new QCard("El interesado tendrá derecho a oponerse en cualquier momento, por motivos relacionados con su situación particular, a qué datos personales que le conciernan sean objeto de un tratamiento basado en el artículo 6, apartado 1, letras e) o f), en la primera frase del artículo 6, apartado 4 leída conjuntamente con el artículo 6, apartado 1, letra e) o en la segunda frase del artículo 6, apartado 4", tipo, "Verdadero", "Falso", "", "", "Verdadero"));
            CartasProteccion.Add(new QCard("El tratamiento de datos personales debe estar concebido para servir a la humanidad", tipo, "Verdadero", "Falso", "", "", "Verdadero"));
            CartasProteccion.Add(new QCard("Todos los datos se tratan de la misma manera, sin excepción ninguna.", tipo, "Verdadero", "Falso", "", "", "Considerando 51 los datos personales que, por su naturaleza, son particularmente sensibles en relación con los derechos y las libertades fundamentales, merecen especial protección ya que el contexto de su tratamiento podría entrañar importantes riesgos para los derechos y las libertades fundamentales."));
            CartasProteccion.Add(new QCard("¿En qué fecha se aprobó la anterior regulación de Protección de datos?", tipo, "El 24 de octubre de 1995", "#", "", "", "El 24 de octubre de 1995"));
            CartasProteccion.Add(new QCard("¿Qué institución es la encargada de comprobar que se cumple el LOPD?", tipo, "", "#", "", "", "La Agencia Española de protección de Datos"));
            CartasProteccion.Add(new QCard("¿Cuando entró en vigor la LOPD?", tipo, "", "#", "", "", "El 6 de diciembre de 2018"));
            CartasProteccion.Add(new QCard("¿Cual es la principal diferencia entre LOPD y RGPD?", tipo, "", "#", "", "", "La LOPD es de carácter nacional y el RGPD es una regulación europea"));
            CartasProteccion.Add(new QCard("Tratar o ceder datos especialmente protegidos es una infracción leve según la LOPD.", tipo, "Verdadero", "Falso", "", "", "Falso"));
            CartasProteccion.Add(new QCard("¿Que se denomina información de carácter personal?", tipo, "", "#", "", "", "Cualquier información concerniente a personas físicas identificadas o identificables, relativa a su identidad como a su existencia y ocupaciones"));
            CartasProteccion.Add(new QCard("¿Cuáles son los nuevos datos de carácter personal que añade el RGPD?", tipo, "", "#", "", "", "Datos genéticos, biométricos y de orientación sexual"));
            CartasProteccion.Add(new QCard("¿Qué son los derechos ARCO?", tipo, "", "#", "", "", "Acceso, Rectificación, Cancelación y Oposición"));
            CartasProteccion.Add(new QCard("Una PYME debe nombrar un Delegado de Protección de datos siempre.", tipo, "Verdadero", "Falso", "", "", "Falso. (Solo debe nombrarlo si su actividad principal constituye el tratamiento de datos personales y su actividad tiene riesgos para las personas)"));
            CartasProteccion.Add(new QCard("El RGPD no establece multas en función del volumen de ingresos de la empresa o bien de cantidades superiores a 10 millones de euros.", tipo, "Verdadero", "Falso", "", "", "Falso( El art. 83 del RGPD establece multas de entre 10 y 20 millones de euros, o bien, un 2 o un 4 % del volumen de negocio del anterior ejercicio)"));
            CartasProteccion.Add(new QCard("Menciona 4 de las bases que regula el RGPD", tipo, "", "#", "", "", "Consentimiento, Interés público, Poderes públicos, Interés legítimo,Obligación legal, Ejecución de un contrato, Intereses vitales"));
            CartasProteccion.Add(new QCard("¿A qué regulación sustituyó el RGPD?", tipo, "", "#", "", "", "Directiva 95/46/CE del Parlamento Europeo y del Consejo"));
            CartasProteccion.Add(new QCard("Debate", tipo, "¿Es correcto que el RGPD establezca multas de hasta 20 millones de euros o hasta un 4% del volumen del negocio anterior?", "", "", "", ""));
        }
        //data privacy questions
        //PENDIENTE
        void LlenarListaPrivacidad(string tipo)
        {
            CartasPrivacidad.Add(new QCard("¿En qué consiste el ad tracking?", tipo, "", "#", "", "", "Tipo de rastreo usando cookies que crea un perfil del usuario con el que determinar que le gusta y que no"));
            CartasPrivacidad.Add(new QCard("Según la Constitución Española de 1978, la privacidad es un derecho de todos los ciudadanos. ¿En qué artículo se define esto?", tipo, "", "#", "", "", "Artículo 18"));
            CartasPrivacidad.Add(new QCard("¿Cuál es la finalidad del cifrado en cuanto a la privacidad?", tipo, "", "#", "", "", "El cifrado es la conversión de datos de un formato legible a un formato codificado, con lo que se impide que alguien robe o lea la información"));
            CartasPrivacidad.Add(new QCard("¿En qué consiste el anonimato?", tipo, "", "#", "", "", "Son los mecanismos que los usuarios usan en internet para ocultar su identidad, no dejando huella en los sitios por los que navegan"));
            CartasPrivacidad.Add(new QCard("¿Qué son los metadatos?", tipo, "", "#", "", "", "Datos que hablan de otros datos, es decir, datos que describen otros datos como el contenido de los archivos o la información de los mismos"));
            CartasPrivacidad.Add(new QCard("¿Qué es o en qué consiste la anonimización de datos?", tipo, "", "#", "", "", "Es el proceso por el que se elimina la posibilidad de identificar a una persona a través de sus datos personales con la finalidad de proteger su privacidad"));
            CartasPrivacidad.Add(new QCard("Actualmente, ¿cuál es la mejor manera de mantener el anonimato?", tipo, "", "#", "", "", "Las Redes Privadas Virtuales (VPN) son el mejor método para usar internet manteniendo el anonimato"));
            CartasPrivacidad.Add(new QCard("¿Cuál es el principal riesgo de la anonimización?", tipo, "", "#", "", "", "El principal riesgo es que se pueda revertir la anonimización, haciendo posible la reidentificación de las personas"));
            CartasPrivacidad.Add(new QCard("Gracias a las filtraciones de Snowden, ¿qué se demandó y se consiguió que se acelerará su implantación?", tipo, "", "#", "", "", "El cifrado de las comunicaciones. Se produjo una ola de indignación que provocó que las grandes compañías como Google o Microsoft empezaran a encriptar el tráfico entre sus centros de servidores"));
            CartasPrivacidad.Add(new QCard("¿Qué es la huella o rastro digital?", tipo, "", "#", "", "", "Es la información que deja cualquier persona, ya sea física o jurídica, en Internet. Cuando se comparte información personal a través de Internet o al utilizar servicios en línea se renuncia a un cierto grado de control sobre la privacidad"));
            CartasPrivacidad.Add(new QCard("Para el borrado de la huella digital, ¿cómo funciona el testamento digital?", tipo, "", "#", "", "", "El testamento digital sirve para especificar nuestras voluntades en cuanto a nuestro legado digital, se puede formalizar ante notario. Aunque no es necesario por ejemplo para borrar una cuenta, facilita el proceso ya que en él se guardan las credenciales de acceso"));
            CartasPrivacidad.Add(new QCard(" En septiembre de 2019 se impuso la multa más elevada a una empresa por infracción de la privacidad, la cuantía fue de 170 millones por compartir y utilizar datos de menores de 13 años sin consentimiento de sus tutores legales. ¿A qué empresa se le impuso?", tipo, "Instagram", "Facebook", "TikTok", "Youtube", "Youtube"));
            CartasPrivacidad.Add(new QCard("Según se refleja en las políticas de privacidad de Google, de la siguiente información, ¿cuál puede recoger con fines de mejorar el servicio o publicitarios?", tipo, "Nacionalidad, historial de búsqueda, calendario de eventos", "Sexo, edad, fotos y videos subidos a redes sociales", "Direcciones IP, correos enviados, contactos añadidos", "Todas las anteriores", "Todas las anteriores"));
            CartasPrivacidad.Add(new QCard("Google permite que gestiones cierta información de la que almacena, ¿qué actividades de las que se guardan te permite controlar?", tipo, "Historial de ubicaciones, historial de búsquedas de YouTube, grabaciones de voz y audio", "Historial de navegación, historial de reproducción de Youtube, dirección personal de correo electrónico", "Historial de ubicaciones, dirección personal de correo electrónico, historial de búsquedas de YouTube", "Historial de ubicaciones, historial de búsquedas de YouTube, nombre y apellidos", "Historial de ubicaciones, historial de búsquedas de YouTube, grabaciones de voz y audio"));
            CartasPrivacidad.Add(new QCard("¿Qué debe ofrecer la criptografía?", tipo, "Confidencialidad, integridad, conexión, no repudio", "Confidencialidad, integridad, autenticación, no repudio", "Confidencialidad, integridad, eficiencia, no repudio", "Confidencialidad, integridad, autenticación, velocidad", "Confidencialidad, integridad, autenticación, no repudio"));
            CartasPrivacidad.Add(new QCard("¿Cuál es la red social que añade metadatos (instrucciones IPTC) a las imágenes de su plataforma para poder rastrearlas fuera de ella?", tipo, "Facebook", "Twitter", "Google Fotos", "Pinterest", "Facebook"));
            CartasPrivacidad.Add(new QCard("El Tribunal de Justicia de la Unión Europea determinó que cualquier usuario tiene derecho a solicitar que los motores de búsqueda eliminen sus datos de las consultas. Se estipuló que de hacerlo, esa información debe desaparecer de las búsquedas.", tipo, "Verdadero", "Falso", "", "", "Falso, basta con que aparezca como irrelevante o inadecuada"));
            CartasPrivacidad.Add(new QCard("Según su política de privacidad, Instagram se compromete a no monitorizar, recolectar o almacenar identificadores del dispositivo con el que te conectas.", tipo, "Verdadero", "Falso", "", "", "Falso, Instagram advierte que puede hacerlo, teniendo en esos identificadores información del hardware, de los datos que almacenas y del sistema operativo. Además pueden compartirlo con terceros del mismo grupo"));
            CartasPrivacidad.Add(new QCard("Los términos Data Mining y Data Harvesting en el ámbito informático no significan lo mismo.", tipo, "Verdadero", "Falso", "", "", "Verdadero, ambos son similares pero en “Data Harvesting” (o recolección de datos) se utiliza un proceso que extrae y analiza los datos recopilados de Internet mientras que “Data Mining” se centra en el análisis de grandes conjuntos de datos"));
            CartasPrivacidad.Add(new QCard("La reducción de datos si se consisera una técnica de anonimización de datos.", tipo, "True", "False", "", "", "Verdadero. Aunque solo se reduzca el número de datos originales, mientras se produzca la suficiente distorsión de los datos para evitar la identificación del usuario será válida"));
            CartasPrivacidad.Add(new QCard("Las filtraciones de Edward Snowden denunciaban el espionaje y la intercepción masiva de las comunicaciones que estaba haciendo el gobierno de EEUU. ¿Qué contestó el presidente de EEUU Barack Obama ante este escándalo?", tipo, "“Los documentos son falsos, solo se interceptan comunicaciones sospechosas.”", "“Si lo que quereis es privacidad no uséis la tecnología.”", "“No se puede tener el 100% de seguridad y el 100% de privacidad.”", "“Esto lo llevaba el vicepresidente, yo no sé nada.”", "“No se puede tener el 100% de seguridad y el 100% de privacidad.”"));
            CartasPrivacidad.Add(new QCard("Debate", tipo, "¿Existe el anonimato? ¿Creeis que es bueno que exista o existiera; o debería limitarse?", "", "", "", ""));
            CartasPrivacidad.Add(new QCard("Debate", tipo, "Las políticas y términos de privacidad es algo que de forma “natural” se suele pasar por alto al ceder nuestros datos en una web, como puede ser por ejemplo una red social. ¿Creeis que esta práctica es algo grave? ¿Deberían las empresas advertir sobre estas políticas y obligar a leerlas?", "", "", "", ""));
            CartasPrivacidad.Add(new QCard("Debate", tipo, "Aunque anonimizados, o al menos debería ser así, muchas empresas venden nuestros datos a terceros para que estos, con fines publicitarios en su mayoría, elaboren perfiles con los que modelar su publicidad. ¿Creeis que esto debería estar permitido? ¿Se debería dar siempre la opción al usuario de poder negarse?", "", "", "", ""));
            CartasPrivacidad.Add(new QCard("Debate", tipo, "La huella o rastro digital es algo que irremediablemente cualquier usuario va dejando al usar Internet. ¿Creeis que debería ser posible que este rastro nunca existiera? Es decir, que existiera la opción de que ninguna web pudiera guardar cualquier información sobre un usuario. ¿Sería factible?", "", "", "", ""));
        }
        //question about facts
        void LlenarListaFact(string tipo)
        {
            CartasFacts.Add(new QCard("Desde 1979 se otorga un premio cuyo nombre se debe a las programadoras del primer computador ENIAC.", tipo, "Verdadero", "Falso", "", "", "Falso (El nombre se debe a los dos hombres que diseñaron la máquina)"));
            CartasFacts.Add(new QCard("El día de Ada Lovelace es un evento anual cuyo objetivo es el de elevar el perfil de las mujeres en la ciencia, tecnología, ingeniería y matemáticas.", tipo, "Verdadero", "Falso", "", "", "Verdadero. (Se celebra en todo el mundo. El evento más importante es el Ada Lovelace Day Live, en Londres)"));
            CartasFacts.Add(new QCard("A partir de febrero Japón intentará colarse en las webcams y los routers de sus ciudadanos.", tipo, "Verdadero", "Falso", "", "", "Verdadero. (Con ello, quieren advertir de lo expuestos que están sus datos)"));
            CartasFacts.Add(new QCard("El estado de California prohíbe crear o distribuir videos deepfake (suplantación de identidad) durante todo el año.", tipo, "Verdadero", "Falso", "", "", "Falso. (Solamente los prohíben 60 días antes de periodos electorales)"));
            CartasFacts.Add(new QCard("Los sistemas tecnológicos de la policía de Chicago identifican tendencias y patrones para predecir crímenes y los lugares donde ocurrirán.", tipo, "Verdadero", "Falso", "", "", "Verdadero. (Poseen sensores, cámaras y equipos de detección de disparos con algoritmos que lo detectan)"));
            CartasFacts.Add(new QCard("Los Androids de gama baja presentan más de 100 aplicaciones preinstaladas susceptibles de explotarse con fines maliciosos.", tipo, "Verdadero", "Falso", "", "", "Verdadero. (Los terminales de bajo coste afectados van desde marcas desconocidas hasta otras como Sony)"));
            CartasFacts.Add(new QCard("Microsoft es la corporación más ética de Estados Unidos.", tipo, "True", "False", "", "","Verdadero. (Lidera el ranking general, seguido por NVIDIA, Apple, Intel… Facebook mientras tanto, permanece en el puesto 149)"));
            CartasFacts.Add(new QCard("El uso de la navegación en modo incógnito permite", tipo, "Enmascarar nuestra identidad o actividad en línea", "Que nuestro jefe no sepa qué páginas hemos visitado", "Eliminar tu información de navegación (contraseñas, cookies e historial)", "Esconder nuestra dirección IP", ""));
            CartasFacts.Add(new QCard("Cualquier fabricante de smartphones o tablets que desee usar Android deberá proporcionar al menos: ", tipo, "4 actualizaciones de seguridad dentro del primer año de lanzamiento", "2 actualizaciones de seguridad dentro del primer año de lanzamiento", "1 actualización de seguridad dentro del primer año de lanzamiento", "2 actualizaciones del dispositivo estando una de ellas enfocada en la seguridad", "4 actualizaciones de seguridad dentro del primer año de lanzamiento"));
            CartasFacts.Add(new QCard("E.E.U.U. quiere desarrollar tanques con inteligencia artificial:", tipo, "Con total autonomía de disparo al objetivo determinado por un humano", "Con autonomía de movimiento, teniendo la posibilidad de veto por un humano", "Con total autonomía de movimiento", "Con autonomía de disparo, teniendo la posibilidad de veto por un humano", "Con autonomía de disparo, teniendo la posibilidad de veto por un humano"));
            CartasFacts.Add(new QCard(" La inteligencia artificial desarrollada para ganar al póquer puede tener aplicaciones en negociaciones financieras y navegación para vehículos autónomos porque:", tipo, "Existe la posibilidad de algún tipo de engaño en las tres situaciones", "Las tres situaciones requieren de una gran capacidad de concentración", "Las tres situaciones involucran a múltiples partes e información faltante", "Las tres situaciones buscan ganar dinero", "Las tres situaciones involucran a múltiples partes e información faltante"));
            CartasFacts.Add(new QCard("El CEO de qué compañía promueve el uso de DuckDuckGo como alternativa a Google (La principal característica de DuckDuckGo es su privacidad).", tipo, "Facebook", "YouTube", "Twitter", "WhatsApp", "Twitter"));
            CartasFacts.Add(new QCard("¿Qué compañía ha tenido ha tenido una brecha mediante la cual se filtraron 40000 tarjetas de crédito de sus clientes?", tipo, "Huawei", "One Plus", "Samsung", "Xiaomi", "One Plus"));
            CartasFacts.Add(new QCard("¿Qué aplicación abre sin permiso tu cámara, pero asegura que no te espía?", tipo, "Facebook", "Whatsapp", "Instagram", "Snapchat", "Facebook"));
            CartasFacts.Add(new QCard("¿Cuántas eran las mujeres que programaron la primera computadora?", tipo, "", "#", "", "", "6"));
            CartasFacts.Add(new QCard("¿Qué navegador activará por defecto el bloqueo de fingerprints? (Técnica de rastreo con la que identificar usuarios a partir de datos técnicos del equipo)", tipo, "", "#", "", "", "Mozilla Firefox"));
            CartasFacts.Add(new QCard("¿Qué aplicación puede cancelarte el acceso a todo o parte de su servicio si tu cuenta no es comercialmente viable?", tipo, "", "", "", "", "YouTube"));
            CartasFacts.Add(new QCard("¿Qué compañía ha desarrollado una cama eléctrica que podemos controlar por voz?", tipo, "", "#", "", "", "Xiaomi"));
           
        }
        //gameflow control cards
        void LLenarListaEspeciales()
        {
            CartasEspeciales.Add(new ACard("¡Pierde turno!", "Cuando estéis listos pasad al turno del siguiente equipo."));
            CartasEspeciales.Add(new ACard("¡Tira otra vez!", "La suerte os sonríe, tenéis otra tirada."));
            CartasEspeciales.Add(new ACard("¡Pierde cable!", "Vuestro equipo elige el color del cable a descartar, si no tenéis ninguno pasad turno."));
            CartasEspeciales.Add(new ACard("¡A rotar!", "Cada equipo cambia su board con el de su derecha."));
        }

        //move the used card from original list to used list so that it won't repeat
        void TraspasarUsadas(QCard carta)
        {
            string k = carta.GetTema();
            switch (k)
            {
                case "Brecha":
                    CartasUsadas.Add(carta);
                    CartasGenero.Remove(carta);
                    break;
                case "Software":
                    CartasUsadas.Add(carta);
                    CartasSoftware.Remove(carta);
                    break;
                case "Proteccion":
                    CartasUsadas.Add(carta);
                    CartasProteccion.Remove(carta);
                    break;
                case "Privacidad":
                    CartasUsadas.Add(carta);
                    CartasPrivacidad.Remove(carta);
                    break;
                case "Facts":
                    CartasUsadas.Add(carta);
                    CartasFacts.Remove(carta);
                    break;
            }
        }


        // Generate a random number between two numbers  
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        QCard ElegirNuevaQCarta(string colorBton)
        {
            QCard krta = null;
            //pick random number
            int ran = RandomNumber(0, 1000);
            //pick a car randomly from the list corresponding to the color of the button clicked
            switch (colorBton)
            {
                case "Violet":
                    if(CartasGenero.Count == 0) { return null; }
                    if(ran == CartasGenero.Count) { ran -= 1; }
                    krta = CartasGenero[ran % CartasGenero.Count];
                    break;
                case "LimeGreen":
                    if (CartasSoftware.Count == 0) { return null; }
                    if (ran == CartasSoftware.Count) { ran -= 1; }
                    krta = CartasSoftware[ran % CartasSoftware.Count];
                    break;
                case "LightSkyBlue":
                    if (CartasProteccion.Count == 0) { return null; }
                    if (ran == CartasProteccion.Count) { ran -= 1; }
                    krta = CartasProteccion[ran % CartasProteccion.Count];
                    break;
                case "DeepPink":
                    if (CartasPrivacidad.Count == 0) { return null; }
                    if (ran == CartasPrivacidad.Count) { ran -= 1; }
                    krta = CartasPrivacidad[ran % CartasPrivacidad.Count];
                    break;
                case "Orange":
                    if (CartasFacts.Count == 0) { return null; }
                    if (ran == CartasFacts.Count) { ran -= 1; }
                    krta = CartasFacts[ran % CartasFacts.Count];
                    break;
            }
            //move the card to the used list
            TraspasarUsadas(krta);
            //assign it to return
            return krta;
        }

        ACard ElegirNuevaACarta()
        {
            //pick random number
            int ran = RandomNumber(0, 100);
            if (ran == CartasEspeciales.Count) { ran -= 1; }
            return CartasEspeciales[ran % CartasEspeciales.Count];
        }

        public ICommand GoNextCard
        {
            get
            {
                return new Command<string>((colorBton) => CallCardView(colorBton));
            }
        }

        public ICommand NextTurn
        {
            
            get 
            {
                return new Command<string>((answer) => CheckAndGo(answer), (usrAns) => CanExecute());
            }

        }

        async void CallCardView(string colorBton)
        {
            int ran = RandomNumber(0, 1000);
            if (ran <= 150)
            {
                ColorTypeConverter converter = new ColorTypeConverter();
                Color color = (Color)(converter.ConvertFromInvariantString(colorBton));
                QCard send = ElegirNuevaQCarta(colorBton);
                if (send != null)
                {
                    await Navigation.PushAsync(new QuestionCardView(color, send) { BindingContext = this, });
                }
                else await Application.Current.MainPage.DisplayAlert("Lo sentimos", "No quedan más cartas de este tipo", "OK");
            }
            else 
            {
                await Navigation.PushAsync(new ActionCardView(ElegirNuevaACarta()) { BindingContext = this,});
            }
        }

        bool CanExecute()
        {
            if (!string.IsNullOrEmpty(usrAns)) 
            {
                return true;
            }
            return false;
        }

        async void CheckAndGo(string answer)
        {
            if(usrAns != "noParam")
            {
                if (usrAns == "SI")
                {
                    Equipos[TurnoTeam - 1].AddAcierto();
                }
                else 
                {
                    Equipos[TurnoTeam - 1].AddFallo();
                }
            }
            ActualizarTurno();
            OnPropertyChanged(nameof(Turno));
            await Navigation.PopAsync();
        }

        public string Turno
        {
            set
            {
                if (turno != value)
                {
                    turno = value;
                    OnPropertyChanged();
                }
            }
            get 
            { 
                return turno; 
            }
        }

        public string UsrAnswer
        {
            set
            {
                if (usrAns != value)
                {
                    usrAns = value;
                    OnPropertyChanged();
                    ((Command)NextTurn)?.ChangeCanExecute();
                }
            }
            get
            {
                return turno;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
