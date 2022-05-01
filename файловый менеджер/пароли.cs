using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace файловый_менеджер
{
    [DataContract]//атрибут
    class пароли
    {
        [DataMember]
        public string пароль { get; set; }
        [DataMember]
        public string логин { get; set; }

        public void сохранить()
        {
            string файл = "пароли.json";//создам потом файл по этому пути с расширением джейсон, чтобы хранить там пароли и логины
            DataContractJsonSerializer sur = new DataContractJsonSerializer(typeof(пароли));//сюреализация будет проходить по полям класса
            FileStream файлик = new FileStream(файл,FileMode.Create);
            sur.WriteObject(файлик,this);

        }
        public static пароли выгрузка()
        {
            string файл = "пароли.json";//создам потом файл по этому пути с расширением джейсон, чтобы хранить там пароли и логины
            DataContractJsonSerializer sur = new DataContractJsonSerializer(typeof(пароли));//сюреализация будет проходить по полям класса
            FileStream файлик = new FileStream(файл, FileMode.Open);
            пароли чел = new пароли();
            чел = (пароли)sur.ReadObject(файлик);
            

            return чел;
        }

    }
}
