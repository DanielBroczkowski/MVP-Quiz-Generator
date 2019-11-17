using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz
{
    class Presenter
    {
        IView view;
        Model model;

        public Presenter(IView view, Model model)
        {
            this.view = view;
            this.model = model;
            this.view.Add += Add_new_question;
            this.view.Exit += Exit;
            this.view.PathEdit += New_Path;
        }
        public void Add_new_question()
        {
            model.Add_new(view.pytanie, view.odp1, view.odp2, view.odp3, view.odp4, view.num1, view.num2, view.num3, view.num4, view.time);
            view.list= model.Add_To_ListBox(view.pytanie);
            czysc();
        }
        public void Exit()
        {
            view.nazwa = model.nazwa();
            model.EndGenerator();
            czysc();
        }
        public void New_Path()
        {
            view.sciezka = model.Path();
        }
        public void czysc()
        {
            view.pytanie = model.clear(view.pytanie);
            view.odp1 = model.clear(view.odp1);
            view.odp2 = model.clear(view.odp2);
            view.odp3 = model.clear(view.odp3);
            view.odp4 = model.clear(view.odp4);
            view.num1 = model.clear_num(view.num1);
            view.num2 = model.clear_num(view.num2);
            view.num3 = model.clear_num(view.num3);
            view.num4 = model.clear_num(view.num4);
        }
    }
}
