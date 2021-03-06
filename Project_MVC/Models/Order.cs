﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project_MVC.Models
{
    public class Order
    {
        public int? Id { get; set; }
        [DisplayName("User Id")]
        public string UserId { get; set; }
        [NotMapped]
        public string UserName { get; set; }
        [DisplayName("Payment Type")]
        public PaymentType PaymentTypeId { get; set; }
        [DisplayName("Ship Name")]
        public string ShipName { get; set; }
        [DisplayName("Ship Address")]
        public string ShipAddress { get; set; }
        [DisplayName("Ship Phone")]
        public string ShipPhone { get; set; }
        [DisplayName("Total Price")]
        public double TotalPrice { get; set; }
        [DisplayName("Created At")]
        public DateTime? CreatedAt { get; set; }
        [DisplayName("Updated At")]
        public DateTime? UpdatedAt { get; set; }
        [DisplayName("Deleted At")]
        public DateTime? DeletedAt { get; set; }
        [DisplayName("Created By")]
        public string CreatedBy { get; set; }
        [DisplayName("Updated By")]
        public string UpdatedBy { get; set; }
        [DisplayName("Deleted By")]
        public string DeletedBy { get; set; }
        public OrderStatus Status { get; set; }
        [ForeignKey("UserId")]
        public virtual AppUser AppUser { get; set; }

        public enum OrderStatus
        {
            Pending = 6, condirmed = 5, Shipping = 4, Paid = 3, Done = 2, Cancel = 1, NotDeleted = 0, Deleted = -1
        }
        public enum PaymentType
        {
            Cod = 1, InternetBanking = 2, DirectTransfer = 3
        }
        public Order()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Status = OrderStatus.Pending;
        }

        internal bool IsDeleted()
        {
            return this.Status == OrderStatus.Deleted;
        }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        //[NotMapped]
        //public virtual ICollection<FlowersInOrderModel> FlowersInOrderModels { get; set; }
    }
}