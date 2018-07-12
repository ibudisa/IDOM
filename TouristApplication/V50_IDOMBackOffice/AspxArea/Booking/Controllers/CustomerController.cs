using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V50_IDOMBackOffice.AspxArea.Booking.Models;
using V50_IDOMBackOffice.AspxArea.Booking.Repositorys;

namespace V50_IDOMBackOffice.AspxArea.Booking.Controllers
{
    public class CustomerController
    {
        public List<CustomerViewModel> Init()
        {
            var list = BookingDataCoreRepository.GetCustomerViewModel();
            return list;
        }
        public void AddCustomer(CustomerViewModel model)
        {
            BookingDataCoreRepository.AddMasterData(model);
        }
        public void UpdateCustomer(CustomerViewModel model)
        {
            BookingDataCoreRepository.UpdateMasterData(model);
        }

        public void DeleteCustomer(string id)
        {
            BookingDataCoreRepository.DeleteCustomer(id);
        }

        public CustomerViewModel GetCustomer(string id)
        {
            return BookingDataCoreRepository.GetCustomer(id);
        }

        public CustomerViewModel GetCustomerById(string id)
        {
            return BookingDataCoreRepository.GetCustomerById(id);
        }
        public LayoutCustomerViewModel GetCustomerLayout(string id)
        {
            return BookingDataCoreRepository.GetLayoutCustomerViewModel(id);
        }

        public List<BookingProcessViewModel> GetBookingProcessesByCustomerId(int customerid)
        {
            return BookingDataCoreRepository.GetBookingProcessessByCustomerId(customerid);
        }

        public void CheckCustomerEmail(string id,string email)
        {
            BookingDataRepository.CheckCustomerEmail(id, email);
        }
    }
}