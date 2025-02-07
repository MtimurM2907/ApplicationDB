using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ApplicationDB
{
    internal class PageController
    {

        private static Database.user8Entities database;
        private static Database.user8Entities Database
        {
            get
            {
                if (database == null)
                {
                    try
                    {
                        database = new Database.user8Entities();
                        if (!database.Database.Exists())
                        {
                            MessageBox.Show("Подключить базу не удалось");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ошибка");
                        database = null;

                    }

                }
                return database;
            }

        }


        private static Authorization _authorization;
        public static Authorization Authorization
        {
            get
            {
                if (_authorization == null)
                {
                    _authorization = new Authorization(Database);
                }
                return _authorization;
            }
        }


        private static RegistrationPage _registration;
        public static RegistrationPage Registration
        {
            get
            {
                if (_registration == null)
                {
                    _registration = new RegistrationPage(Database);
                }
                return _registration;

            }

        }



        private static PageStudent _pageStudent;
        public static PageStudent PageStudent
        {
            get
            {
                if (_pageStudent == null)
                {
                    _pageStudent = new PageStudent();
                }
                return _pageStudent;
            }
        }

        private static PageTeacher _pageTeacher;
        public static PageTeacher PageTeacher
        {
            get
            {
                if (_pageTeacher == null)
                {
                    _pageTeacher = new PageTeacher();
                }
                return _pageTeacher;
            }
        }
    }
}
