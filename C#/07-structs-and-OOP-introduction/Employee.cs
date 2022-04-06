using System;

namespace Homework_07
{
    /// <summary>
    /// Структура данных записи
    /// </summary>
    public struct Employee
    {
        #region Поля

        /// <summary>
        /// Поле "Идентификатор"
        /// </summary>
        private int id;

        /// <summary>
        /// Поле "Время добавления"
        /// </summary>
        private DateTime timeOfAdding;
        
        /// <summary>
        /// Поле "ФИО"
        /// </summary>
        private string fullName;
        
        /// <summary>
        /// Поле "Возраст"
        /// </summary>
        private int age;
        
        /// <summary>
        /// Поле "Рост"
        /// </summary>
        private uint growth;
        
        /// <summary>
        /// Поле "Дата рождения"
        /// </summary>
        private DateTime birthday;
        
        /// <summary>
        /// Поле "Место рождения"
        /// </summary>
        private string placeOfBirth;

        #endregion

        #region Свойства

        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id
        {
            get { return this.id; }
        }

        /// <summary>
        /// Время добавления
        /// </summary>
        public DateTime TimeOfAdding 
        { 
            get { return this.timeOfAdding; }
        }

        /// <summary>
        /// ФИО
        /// </summary>
        public string FullName
        {
            get { return this.fullName; }
            set { this.fullName = value; }
        }

        /// <summary>
        /// Рост
        /// </summary>
        public uint Growth 
        {
            get { return this.growth; }
            set { this.growth = value; }
        }

        #endregion

        #region Конструктор

        /// <summary>
        /// Создание сотрудника
        /// </summary>
        /// <param name="fullName">ФИО</param>
        /// <param name="growth">Рост</param>
        /// <param name="birthday">Дата рождения</param>
        /// <param name="placeOfBirth">Место рождения</param>
        public Employee(int id, string fullName, uint growth, DateTime birthday, string placeOfBirth, DateTime timeOfAdding)
        {
            this.id = id;
            this.timeOfAdding = timeOfAdding;
            this.fullName = fullName;
            age = DateTime.Now.Year - birthday.Year - (((DateTime.Now.Month < birthday.Month) ||
            ((DateTime.Now.Month == birthday.Month) && (DateTime.Now.Day < birthday.Day))) ? 1 : 0);
            this.growth = growth;
            this.birthday = birthday.Date;
            this.placeOfBirth = placeOfBirth;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Создание форматированной строки для записи в файл
        /// </summary>
        /// <returns>Строка для записи</returns>
        public string ToInputString()
        {
            return $"{id}#{timeOfAdding.ToShortDateString()} {timeOfAdding.ToShortTimeString()}#{fullName}#{age}#{growth}#{birthday.ToShortDateString()}#{placeOfBirth}";
        }

        /// <summary>
        /// Создание форматированной строки для вывода в консоль
        /// </summary>
        /// <returns>Строка для вывода</returns>
        public string ToOutputString()
        {
            return $"{id,5} {timeOfAdding.ToShortDateString() + " " + timeOfAdding.ToShortTimeString(),20} {fullName,15} {age,10} {growth,10} {birthday.ToShortDateString(),15} {placeOfBirth,15}";
        }

        /// <summary>
        /// Обновление возраста
        /// </summary>
        public void UpdateAge()
        { 
            age = DateTime.Now.Year - birthday.Year - (((DateTime.Now.Month < birthday.Month) ||
            ((DateTime.Now.Month == birthday.Month) && (DateTime.Now.Day < birthday.Day))) ? 1 : 0);
        }

        #endregion
    }
}

