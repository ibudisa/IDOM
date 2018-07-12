using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdomOffice.Interface.BackOffice.Booking.Core;
using IdomOffice.Interface.BackOffice.Booking.Documents;

namespace IdomOffice.Interface.BackOffice.Booking
{
    public interface IBookingDataManager
    {
        void AddMasterData(Customer document);
        void AddMasterData(Provider document);
        void AddMasterData(BookingConfirmation document);
        void AddMasterData(BookingInquiry document);
        void AddMasterData(BookingInvoice document);
        void AddMasterData(CustomerVoucher document);
        void AddMasterData(BookingProcess document);
        void AddMasterData(BookingProcessItem document);
        void AddMasterData(B2BCustomer document);
        void AddMasterData(Email document);
        void AddMasterData(Template document);
        void AddMasterData(TextInfo document);
        void AddMasterData(TravelApplicantPaymentData document);
        void AddMasterData(ProviderPaymentData document);
        void AddMasterData(ApplicationKey document);
        void AddMasterData(ProviderAnnouncement document);
        void AddMasterData(ProviderConfirmation document);

        void UpdateMasterData(Customer document);
        void UpdateMasterData(Provider document);
        void UpdateMasterData(BookingConfirmation document);
        void UpdateMasterData(BookingInquiry document);
        void UpdateMasterData(BookingInvoice document);
        void UpdateMasterData(CustomerVoucher document);
        void UpdateMasterData(BookingProcess document);
        void UpdateMasterData(BookingProcessItem document);
        void UpdateMasterData(B2BCustomer document);
        void UpdateMasterData(Template document);
        void UpdateMasterData(ApplicationKey document);
        void UpdateMasterData(ProviderAnnouncement document);
        void UpdateMasterData(ProviderConfirmation document);

        Customer GetCustomer(string id);
        Customer GetCustomerByEmail(string email);
        Customer GetCustomerByCustomerNr(int customerNr);
        List<Customer> GetCustomers();
        Provider GetProviderForProviderId(int providerId);
        Provider GetProvider(string id);
        Provider GetProviderByName(string name);
        List<Provider> GetProviders();

        Email GetEmail(string id);
        List<Email> GetEmails();
        Email GetEmailByBookingIdLast(string bookingid);

        TextInfo GetTextInfo(string id);
        List<TextInfo> GetTextInfos();

        TravelApplicantPaymentData GetApplicantPayment(string id);
        List<TravelApplicantPaymentData> GetApplicantPayments();
        List<TravelApplicantPaymentData> GetApplicantPaymentsByBookingId(string id);

        ProviderPaymentData GetProviderPayment(string id);
        List<ProviderPaymentData> GetProviderPayments();
        List<ProviderPaymentData> GetProviderPaymentsByBookingId(string id);

        ApplicationKey GetApplicationKey(string id);
        List<ApplicationKey> GetApplicationKeys();
        ApplicationKey GetApplicationKeyByName(string name);

        BookingConfirmation GetBookingConfirmation(string id);
        List<BookingConfirmation> GetBookingConfirmations();
        BookingConfirmation GetBookingConfirmationByBookingId(string bookingid);

        BookingInquiry GetBookingInquiry(string id);
        BookingInquiry GetBookingInquiryByNumber(string number);
        List<BookingInquiry> GetBookingInquires();

        ProviderAnnouncement GetProviderAnnouncement(string id);
        ProviderAnnouncement GetProviderAnnouncementByBookingId(string id);
        List<ProviderAnnouncement> GetProviderAnnouncements();

        ProviderConfirmation GetProviderConfirmation(string id);
        ProviderConfirmation GetProviderConfirmationByBookingId(string id);
        List<ProviderConfirmation> GetProviderConfirmations();

        BookingInvoice GetBookingInvoice(string id);       
        List<BookingInvoice> GetBookingInvoices();

        CustomerVoucher GetCustomerVoucherById(string id);
        List<CustomerVoucher> GetCustomerVouchers();


        BookingProcess GetBookingProcess(string id);
        List<BookingProcess> GetBookingProcessByCustomerId(int customerid);
        List<BookingProcess> GetBookingProcessByPartnerId(int partnerid);
        List<BookingProcess> GetBookingProcessByProviderId(int providerid);
        List<BookingProcess> GetBookingProcesses();

        BookingProcessItem BookingProcessItemById(string id);
        List<CustomerVoucher> GetBookingProcessItems();


        B2BCustomer GetB2BCustomer(string id);
        List<B2BCustomer> GetB2BCustomers();

        Template GetTemplate(string id);
        List<Template> GetTemplates();
        List<Template> GetTemplatesByStatusId(string statusid);

        void DeleteBookingProcess(string id);
        void DeleteProvider(string id);
        void DeleteB2BCustomer(string id);
        void DeleteCustomer(string id);
        void DeleteTemplate(string id);
       
    }
}
