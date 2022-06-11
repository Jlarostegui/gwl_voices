import { IterableDiffers } from "@angular/core";

export class User {

  Id?: number;
  Username?: string;
  Password?: string;
  Rol?: string;
  Name?: string;
  Surname?: string;
  Email?: string;
  Img?: string;
  Phone?: string;
  Adress?: string;
  UrlGwl?: string;

  constructor(item?: Partial<User>) {

    this.Id = item?.Id;
    this.Username = item?.Username;
    this.Password = item?.Password;
    this.Rol = item?.Rol;
    this.Name = item?.Name;
    this.Surname = item?.Surname;
    this.Email = item?.Email;
    this.Img = item?.Img;
    this.Phone = item?.Phone;
    this.Adress = item?.Adress;
    this.UrlGwl = item?.UrlGwl;

  }










}