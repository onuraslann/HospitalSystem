using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
   public static class Messages
    {
        public static string DoctorAdded = "Doktor  eklendi";
        public static string Prescription = "Reçete oluşturuldu";
        public static string AppointmentAdded = "Randevu başarılı bir şekilde oluşturuldu";
        public static string AppointmentDeleted = "Randevu silindi";
        public static string SickAdded = "Hasta eklendi";
        public static string CheckIfTcExist = "Tc numarası aynı olamaz";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UsersAdded = "Kullanıcı eklendi";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Geçersiz parola";
        public static string SuccessLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Mevcut kullanıcı";
        public static string AccessTokenAdded = "Token başarılı bir şekilde oluşturuldu";
    }
}
