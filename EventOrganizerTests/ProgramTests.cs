using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventOrganizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventOrganizer.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void ProcessSpeechTest()
        {
            List<Speech> speeches = new List<Speech>();
            speeches.Add(new Speech("Dr. Ruy Ramos", " Certificado de Atributo", 60));
            speeches.Add(new Speech("Dr. Fabiano Menke", " Diretivas da Assinatura Digital", 45));
            speeches.Add(new Speech("Luiz Carlos Zancanella Junior", " Carimbo de Tempo", 30));
            speeches.Add(new Speech("Ireneu Orth", " Case Tapera", 45));
            speeches.Add(new Speech("Dr. Renato Martini", " Visão da Presidência da República", 45));
            speeches.Add(new Speech("Antônio Gomes", " Visão do Estado do Rio Grande do Sul", 5));
            speeches.Add(new Speech("Famurs", " Visão dos Municipios", 60));
            speeches.Add(new Speech("Carlos Eduardo Wagner", " Certificado Digital no Banrisul", 45));
            speeches.Add(new Speech("Cynthia Anzanello", " Certificação na administração pública estadual do RS ", 30));
            speeches.Add(new Speech("Paulo Roberto Kopschina", " Serviços da Jucergs que fazem uso do certificado digital", 30));
            speeches.Add(new Speech("Dr. Júlio César Fonseca", " A experiência do escritório Mattos Filho com certificado", 45));
            speeches.Add(new Speech("André Luiz Assis", " O uso do certificado ICP-Brasil no IGP-RS", 60));
            speeches.Add(new Speech("Pedro Paulo Lemos", " Mesa Aberta", 60));
            speeches.Add(new Speech("Nivaldo Cleto", " Apresentação AARB", 45));
            speeches.Add(new Speech("Regina Tupinambá", " A comunicação no mundo da certificação digital", 30));
            speeches.Add(new Speech("Junior Fuganholi", " Palestra Parcerias com as ARs –Startup Xml NFe Estadual", 30));
            speeches.Add(new Speech("Patrícia  T Oliveira Leite", " Palestra de Compliance", 60));
            speeches.Add(new Speech("Maurício Coelho", " ICP-Brasil: Perspectivas e Números", 30));
            speeches.Add(new Speech("Adriano Carlos Gliorsi", " Certificação Digital na saúde", 30));

            Period period1D1 = new Period("09:00", "12:00", "12:00", "Almoço"); //Start time, End Time, Limit Event, Limit Event Name
            Period period2D1 = new Period("13:00", "17:00", "17:00", "Dúvidas e Debates"); //Start time, End Time, Limit Event, Limit Event Name 
            Period period1D2 = new Period("09:00", "12:00", "12:00", "Almoço"); //Start time, End Time, Limit Event, Limit Event Name
            Period period2D2 = new Period("13:00", "17:00", "17:00", "Dúvidas e Debates"); //Start time, End Time, Limit Event, Limit Event Name

            List<Period> periodList = new List<Period>();

            periodList.Add(period1D1);
            periodList.Add(period2D1);
            periodList.Add(period1D2);
            periodList.Add(period2D2);

            Program.ProcessSpeech(speeches, periodList);
            
        }

        [TestMethod()]
        public void empty_input()
        {
            List<Speech> speeches = new List<Speech>();           
            List<Period> periodList = new List<Period>();
                       
            Program.ProcessSpeech(speeches, periodList);
            
        }

        [TestMethod()]
        public void null_input()
        {
            List<Speech> speeches = new List<Speech>();
            List<Period> periodList = new List<Period>();

            Program.ProcessSpeech(null, periodList);

        }

        [TestMethod()]
        public void null_input2()
        {
            List<Speech> speeches = new List<Speech>();
            List<Period> periodList = new List<Period>();

            Program.ProcessSpeech(null, null);

        }
        [TestMethod()]
        public void null_input3()
        {
            List<Speech> speeches = new List<Speech>();
            List<Period> periodList = new List<Period>();

            Program.ProcessSpeech(speeches, null);

        }
        /*I would create a testcase for incomplete data, but I created constructors for receiving data directly, thus it
            does not enable the creation of an incomplete entry

        [TestMethod()]
        public void incomplete_data()
        {

        }
    */
    }
}