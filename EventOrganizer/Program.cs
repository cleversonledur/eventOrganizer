using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventOrganizer
{
    public class Program
    {
        /// <summary>
        /// In main we must insert the data about the speeches and the event settings.
        /// The first step is to create a List of speech objects with the Talker, Title and duration.
        /// After we created a List with periods. Each part of the day is a period, then all speeches in the 
        /// morning will be part of a period. All speeches in the afternoon will be part of another period.
        /// We call the ProcessSpeech method passing a list of speeches and a list of periods. 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            List<Speech> speeches = new List<Speech>();
            speeches.Add(new Speech("Dr. Ruy Ramos", " Certificado de Atributo", 60));
            speeches.Add(new Speech("Dr. Fabiano Menke"," Diretivas da Assinatura Digital" ,45));
            speeches.Add(new Speech("Luiz Carlos Zancanella Junior"," Carimbo de Tempo" ,30));
            speeches.Add(new Speech("Ireneu Orth"," Case Tapera" ,45));
            speeches.Add(new Speech("Dr. Renato Martini"," Visão da Presidência da República" ,45));
            speeches.Add(new Speech("Antônio Gomes"," Visão do Estado do Rio Grande do Sul" ,5));
            speeches.Add(new Speech("Famurs"," Visão dos Municipios" ,60));
            speeches.Add(new Speech("Carlos Eduardo Wagner"," Certificado Digital no Banrisul" ,45));
            speeches.Add(new Speech("Cynthia Anzanello", " Certificação na administração pública estadual do RS ",30 ));
            speeches.Add(new Speech("Paulo Roberto Kopschina"," Serviços da Jucergs que fazem uso do certificado digital" ,30));
            speeches.Add(new Speech("Dr. Júlio César Fonseca"," A experiência do escritório Mattos Filho com certificado" ,45));
            speeches.Add(new Speech("André Luiz Assis"," O uso do certificado ICP-Brasil no IGP-RS" ,60));
            speeches.Add(new Speech("Pedro Paulo Lemos"," Mesa Aberta" ,60));
            speeches.Add(new Speech("Nivaldo Cleto"," Apresentação AARB" ,45));
            speeches.Add(new Speech("Regina Tupinambá"," A comunicação no mundo da certificação digital" ,30));
            speeches.Add(new Speech("Junior Fuganholi"," Palestra Parcerias com as ARs –Startup Xml NFe Estadual" ,30));
            speeches.Add(new Speech("Patrícia  T Oliveira Leite"," Palestra de Compliance" ,60));
            speeches.Add(new Speech("Maurício Coelho"," ICP-Brasil: Perspectivas e Números" ,30));
            speeches.Add(new Speech("Adriano Carlos Gliorsi"," Certificação Digital na saúde" ,30));

            Period period1D1 = new Period("09:00", "12:00","12:00","Almoço"); //Start time, End Time, Limit Event, Limit Event Name
            Period period2D1 = new Period("13:00", "17:00", "17:00", "Dúvidas e Debates"); //Start time, End Time, Limit Event, Limit Event Name 
            Period period1D2 = new Period("09:00", "12:00", "12:00", "Almoço"); //Start time, End Time, Limit Event, Limit Event Name
            Period period2D2 = new Period("13:00", "17:00", "17:00", "Dúvidas e Debates"); //Start time, End Time, Limit Event, Limit Event Name

            List<Period> periodList = new List<Period>();

            periodList.Add(period1D1);
            periodList.Add(period2D1);
            periodList.Add(period1D2);
            periodList.Add(period2D2);

            ProcessSpeech(speeches,periodList);
        }

        /// <summary>
        /// The first step in the ProcessSpeech is to verify integrity of data.
        /// After, we sort the speech list in order to positionate the ones with greater duration first.
        /// Then, using a simple strategy we allocate the speeches with greater duration first.
        /// Another possibility would be to use a evolutionary, a Best-fit or a brute-force algorithm to solve this.
        /// However, in order to do not take high-levels of processing and code complexity, I believe this strategy 
        /// fits the problem since this allocates well the speeches in the available spaces. I also decided to implement this
        /// simpler strategy in order to focus on the code organization and understanding.
        /// </summary>
        /// <param name="speeches"></param>
        /// <param name="periodList"></param>
        public static void ProcessSpeech(List<Speech> speeches, List<Period> periodList)
        {
            try
            {
                /*The next If statement will verify if the lists are empty or null*/
                if (speeches == null || periodList == null||speeches.Count == 0 || periodList.Count == 0)
                {
                    return;
                }
            }
            catch (Exception e)
            {
                return;
            }
            try
            {
                foreach (var data in periodList)
                {
                    data.Validate();
                }
            }catch(Exception e)
            {
                return;
            }

            /*The next line will sort the list according to the duration time.*/
            List<Speech> sortedList = speeches.OrderByDescending(o => o.Time).ToList(); //Ordering by time

            //sortedList.OrderBy(o => o.Name)

            for (int i = 0; i < sortedList.Count; i++)
            {
                int control = i;
                for (int j = 0; j < periodList.Count; j++)
                {
                    if (periodList[j].emptyTime() >= sortedList[i].Time)
                    {
                        Console.WriteLine("Inserting " + sortedList[i].Time);
                        periodList[j].eventList.Add(sortedList[i]);
                        i++;
                    }
                }
                if (control == i)
                {
                    Console.WriteLine("Error inserting ");
                }
            }

            /*
             * Printing the speeches in order.
             */
            for(int i = 0; i< periodList.Count; i++)
            {
                DateTime start = periodList[i].Start;
                for (int j =0; j< periodList[i].eventList.Count; j++)
                {
                    Console.WriteLine(start.TimeOfDay + "\t" + periodList[i].eventList[j].Name + ": " + periodList[i].eventList[j].Title + "\t" + periodList[i].eventList[j].Time + "min");
                    start = start.AddMinutes(periodList[i].eventList[j].Time);
                }
                Console.WriteLine(periodList[i].Specialend.TimeOfDay + " " + periodList[i].Specialend_name);
            }

           
            //Console.ReadKey();
        }
    }
}
