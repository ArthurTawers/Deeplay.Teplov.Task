using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deeplay.Teplov.TestWork.BL;
using Deeplay.Teplov.TestWork.View;

namespace Deeplay.Teplov.TestWork.Presenter
{
    internal class Presenter
    {
        private readonly IMainForm mainForm;
        private readonly IModel myModel;
        private readonly IMessageService messageService;

        private int idTable;
        public Presenter(View.MainForm form, IModel model,IMessageService messageService)
        {
            mainForm = form;
            myModel = model;
            this.messageService = messageService;
            mainForm.Initialize+=InitDataFromDb;
            mainForm.idTableChange+=IdTableChanged;
            mainForm.UpdateLine+=UpdateLine;
            mainForm.DeleteLine+=DeleteLine;
            mainForm.AddForm.AddLine+=AddLine;
            mainForm.PromotionLine+=PromotionLine;
            mainForm.SelectDivision+=SelectDivisions;
        }
        void SelectDivisions(object sender, EventArgs e)
        {
            DataSet set = myModel.getDivisionTable(mainForm.CurrentDivision);

            if (set==null || set.Tables.Count == 0)
            {
                messageService.ShowError("записей нету!");
                return;
            }
            mainForm.dgsView.DataSource = set.Tables[0];
            mainForm.dgsDataSet = set;
        }
        void PromotionLine(object sender, EventArgs e)
        {
            if (idTable == 3)
            {
                messageService.ShowError("Данная должность является максимальной!");
                return;
            }
            try
            {
                switch (idTable)
                {
                    case 0:
                        myModel.DeleteWorkerLine(mainForm.IdLine);
                        myModel.AddControllersLine(mainForm.DateLine, mainForm.FioLine, mainForm.GenderLine, mainForm.InfoLine);
                        break;
                    case 1:
                        myModel.DeleteControllerLine(mainForm.IdLine);
                        myModel.AddHeadDepartmentLine(mainForm.DateLine, mainForm.FioLine, mainForm.GenderLine, mainForm.InfoLine);
                        break;
                    case 2:
                        myModel.DeleteHeadepartmentLine(mainForm.IdLine);
                        myModel.AddDirectorsLine(mainForm.DateLine, mainForm.FioLine, mainForm.GenderLine, mainForm.InfoLine);
                        break;
                }
                messageService.ShowMessage("Успешно повысиили!");
            }
            catch(Exception ex)
            {
                messageService.ShowError(ex.Message);
            }
        }

        void AddLine(object sender, EventArgs e)
        {
            try
            {
                switch (mainForm.AddForm.idTable)
                {
                    case 0:
                        myModel.AddWorkerLine(mainForm.AddForm.DateLine, mainForm.AddForm.FioLine, mainForm.AddForm.GenderLine, mainForm.AddForm.InfoLine);
                        break;
                    case 1:
                        myModel.AddControllersLine(mainForm.AddForm.DateLine, mainForm.AddForm.FioLine, mainForm.AddForm.GenderLine, mainForm.AddForm.InfoLine);
                        break;
                    case 2:
                        myModel.AddHeadDepartmentLine(mainForm.AddForm.DateLine,mainForm.AddForm.FioLine,mainForm.AddForm.GenderLine,mainForm.AddForm.InfoLine);
                        break;
                    case 3:
                        myModel.AddDirectorsLine(mainForm.AddForm.DateLine, mainForm.AddForm.FioLine, mainForm.AddForm.GenderLine, mainForm.AddForm.InfoLine);
                        break;

                }
                messageService.ShowMessage("Успешно добавлено!");
            }
            catch (Exception ex)
            {
                messageService.ShowError(ex.Message);
            }
        }

        void DeleteLine(object sender, EventArgs e)
        {
            try
            {
                switch (idTable)
                {
                    case 0:
                        myModel.DeleteWorkerLine(mainForm.IdLine);
                        break;
                    case 1:
                        myModel.DeleteControllerLine(mainForm.IdLine);
                        break;
                    case 2:
                        myModel.DeleteHeadepartmentLine(mainForm.IdLine);
                        break;
                    case 3:
                        myModel.DeleteDirectorsLine(mainForm.IdLine);
                        break;

                }
                messageService.ShowMessage("Успешно удалено!");
            }
            catch (Exception ex)
            {
                messageService.ShowError(ex.Message);
            }
        }

        void IdTableChanged(int id)
        {
            idTable = id;
        }

        void UpdateLine(object sender, EventArgs e)
        {
            try
            {
                switch (idTable)
                {
                    case 0:                       
                       myModel.UpdateWorker(mainForm.IdLine, mainForm.DateLine, mainForm.FioLine, mainForm.GenderLine, mainForm.InfoLine);                      
                        break;
                    case 1:
                        myModel.UpdateControllers(mainForm.IdLine, mainForm.DateLine, mainForm.FioLine, mainForm.GenderLine, mainForm.InfoLine);             
                        break;
                    case 2:
                        myModel.UpdateHeadDepartment(mainForm.IdLine, mainForm.DateLine, mainForm.FioLine, mainForm.GenderLine, mainForm.InfoLine);
                        break;
                    case 3:
                        myModel.UpdateDirectors(mainForm.IdLine, mainForm.DateLine, mainForm.FioLine, mainForm.GenderLine, mainForm.InfoLine);
                        break;

                }
                messageService.ShowMessage("Успешно сохранено!");
            }
            catch (Exception ex)
            {
                messageService.ShowError(ex.Message);
            }
        }

        void InitDataFromDb(object sender, EventArgs e)
        {
            DataSet set;
            try
            {
                switch (idTable)
                {
                    case 0:
                        set = myModel.getWoerkerTable();
                        mainForm.dgsView.DataSource = set.Tables[0];
                        mainForm.dgsDataSet = set;
                        break;
                    case 1:
                        set = myModel.getControllersTable();
                        mainForm.dgsView.DataSource = set.Tables[0];
                        mainForm.dgsDataSet = set;
                        break;
                    case 2:
                        set = myModel.getHeadDepartmentTable();
                        if(idTable==2)
                        {
                            mainForm.DivisionItems = myModel.getDivisions();
                        }
                        if (set==null)
                        {
                            messageService.ShowError("записей нету!");
                            return;
                        }
                        mainForm.dgsView.DataSource = set.Tables[0];
                        mainForm.dgsDataSet = set;
                        break;
                    case 3:
                        set = myModel.getDirectorsTable();
                        mainForm.dgsView.DataSource = set.Tables[0];
                        mainForm.dgsDataSet = set;
                        break;

                }
            }
            catch (Exception ex)
            {
                messageService.ShowError(ex.Message);
            }
        }
    }
}
