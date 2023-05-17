using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VigProject_Api.Global;
using VigProject_Api.Model;
using VigProject_Api.Repository;

namespace VigProject_Api.Controllers
{

    [Route("api/payroll")]
    [ApiController]
    public class PayRollController : Controller
    {
        Payroll_Repository objCitiRepo = new Payroll_Repository();

        [HttpGet]
        [Route("getEmployeeList")]
        public async Task<IActionResult> getEmployeeList(string empname, string mobileno)
        {
            try
            {
                EmployeeModel objRetModel = new EmployeeModel();
                objRetModel.EmployeeListModel = await objCitiRepo.repo_GetEmployeeList("payroll", empname, mobileno);
                if (objRetModel.EmployeeListModel.Count > 0)
                    objRetModel.status = ResponseStatus.SUCCESS;
                else
                {
                    objRetModel.status = ResponseStatus.FAILED;
                }
                return Ok(new { results = objRetModel });
            }
            catch (Exception ex)
            {
                return Ok(new { results = ex.Message });
            }
        }


        [HttpPost]
        [Route("setNewEmployee")]
        public async Task<IActionResult> setNewEmployee(SetEmployeeReq _setEmployeeReq)
        {
            try
            {
                string Id = "";
                Id = await objCitiRepo.repo_SetNewEmployee("payroll", _setEmployeeReq);
                //if (objRetModel.EmployeeListModel.Count > 0)
                //    objRetModel.status = ResponseStatus.SUCCESS;
                //else
                //{
                //    objRetModel.status = ResponseStatus.FAILED;
                //}
                return Ok(new { results = Id });
            }
            catch (Exception ex)
            {
                return Ok(new { results = ex.Message });
            }
        }

        [HttpPost]
        [Route("setBankMasterSetting")]
        public async Task<IActionResult> setBankMasterSetting(SetBankSetting _setEmployeeReq)
        {
            try
            {
                string Id = "";
                Id = await objCitiRepo.repo_EMPSet_BankMasterSetting("payroll", _setEmployeeReq);
                //if (objRetModel.EmployeeListModel.Count > 0)
                //    objRetModel.status = ResponseStatus.SUCCESS;
                //else
                //{
                //    objRetModel.status = ResponseStatus.FAILED;
                //}
                return Ok(new { results = Id });
            }
            catch (Exception ex)
            {
                return Ok(new { results = ex.Message });
            }
        }

        [HttpGet]
        [Route("gettBankMasterSetting")]
        public async Task<IActionResult> gettBankMasterSetting()
        {
            try
            {
                BankSettingModel objRetModel = new BankSettingModel();
                objRetModel._SetBankSetting = await objCitiRepo.repo_gettBankMasterSetting("payroll");
                if (objRetModel._SetBankSetting.Count > 0)
                    objRetModel.status = ResponseStatus.SUCCESS;
                else
                {
                    objRetModel.status = ResponseStatus.FAILED;
                }
                return Ok(new { results = objRetModel });
            }
            catch (Exception ex)
            {
                return Ok(new { results = ex.Message });
            }
        }

        [HttpPost]
        [Route("setmployeeSalarySetting")]
        public async Task<IActionResult> setmployeeSalarySetting(EmployeeSalarySettingList_in _EmployeeSalarySettingList)
        {
            try
            {
                string Id = "";
                Id = await objCitiRepo.repo_setmployeeSalarySetting("payroll", _EmployeeSalarySettingList);
                //if (objRetModel.EmployeeListModel.Count > 0)
                //    objRetModel.status = ResponseStatus.SUCCESS;
                //else
                //{
                //    objRetModel.status = ResponseStatus.FAILED;
                //}
                return Ok(new { results = Id });
            }
            catch (Exception ex)
            {
                return Ok(new { results = ex.Message });
            }
        }


        [HttpGet]
        [Route("getEmployeeSalarySettingList")]
        public async Task<IActionResult> getEmployeeSalarySettingList(int empid)
        {
            try
            {
                EmployeeSalarySettingmodel objRetModel = new EmployeeSalarySettingmodel();
                objRetModel.EmployeeSalarySettingList = await objCitiRepo.repo_getEmployeeSalarySettingList("payroll", empid);
                if (objRetModel.EmployeeSalarySettingList.Count > 0)
                    objRetModel.status = ResponseStatus.SUCCESS;
                else
                {
                    objRetModel.status = ResponseStatus.FAILED;
                }
                return Ok(new { results = objRetModel });
            }
            catch (Exception ex)
            {
                return Ok(new { results = ex.Message });
            }
        }

        [HttpPost]
        [Route("setLoanMaster")]
        public async Task<IActionResult> setLoanMaster(EmpLoanMasterInput _EmpLoanMasterInput)
        {
            try
            {
                string Id = "";
                Id = await objCitiRepo.repo_setLoandMaster("payroll", _EmpLoanMasterInput);
                //if (objRetModel.EmployeeListModel.Count > 0)
                //    objRetModel.status = ResponseStatus.SUCCESS;
                //else
                //{
                //    objRetModel.status = ResponseStatus.FAILED;
                //}
                return Ok(new { results = Id });
            }
            catch (Exception ex)
            {
                return Ok(new { results = ex.Message });
            }
        }

        [HttpGet]
        [Route("getLoanMaster")]
        public async Task<IActionResult> getLoanMaster(int empid, int loanid)
        {
            try
            {
                EmpLoanMasterModel objRetModel = new EmpLoanMasterModel();
                objRetModel.EmpLoanMasterInput = await objCitiRepo.repo_getLoanMaster("payroll", empid, loanid);
                if (objRetModel.EmpLoanMasterInput.Count > 0)
                    objRetModel.status = ResponseStatus.SUCCESS;
                else
                {
                    objRetModel.status = ResponseStatus.FAILED;
                }
                return Ok(new { results = objRetModel });
            }
            catch (Exception ex)
            {
                return Ok(new { results = ex.Message });
            }
        }


        [HttpPost]
        [Route("setEmployeeSalaryIncrement")]
        public async Task<IActionResult> setEmployeeSalaryIncrement(EmpSalaryIncrementInput _EmpSalaryIncrementInput)
        {
            try
            {
                string Id = "";
                Id = await objCitiRepo.repo_setEmployeeSalaryIncrement("payroll", _EmpSalaryIncrementInput);
                //if (objRetModel.EmployeeListModel.Count > 0)
                //    objRetModel.status = ResponseStatus.SUCCESS;
                //else
                //{
                //    objRetModel.status = ResponseStatus.FAILED;
                //}
                return Ok(new { results = Id });
            }
            catch (Exception ex)
            {
                return Ok(new { results = ex.Message });
            }
        }

        [HttpGet]
        [Route("getEmployeeSalaryIncrement")]
        public async Task<IActionResult> getEmployeeSalaryIncrement()
        {
            try
            {
                EmpSalaryIncrementModel objRetModel = new EmpSalaryIncrementModel();
                objRetModel._EmpSalaryIncrementOutPut = await objCitiRepo.repo_getEmployeeSalaryIncrement("payroll");
                if (objRetModel._EmpSalaryIncrementOutPut.Count > 0)
                    objRetModel.status = ResponseStatus.SUCCESS;
                else
                {
                    objRetModel.status = ResponseStatus.FAILED;
                }
                return Ok(new { results = objRetModel });
            }
            catch (Exception ex)
            {
                return Ok(new { results = ex.Message });
            }
        }

    }
}
