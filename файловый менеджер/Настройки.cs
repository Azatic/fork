using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace файловый_менеджер
{
    [DataContract]//атрибут
    class Настройки
    {
        [DataMember]
        public string пароль { get; set; }
        [DataMember]
        public string логин { get; set; }

        public void сохранить()
        {
            string файл = "пароли.json";//создам потом файл по этому пути с расширением джейсон, чтобы хранить там пароли и логины
            DataContractJsonSerializer sur = new DataContractJsonSerializer(typeof(Настройки));//сюреализация будет проходить по полям класса
            FileStream файл = new FileStream(,) ;

        }


    }
}
