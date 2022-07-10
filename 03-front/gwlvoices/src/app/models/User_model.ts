export class User {

  id?: number;
  username?: string;
  password?: string;
  rol?: string;
  name?: string;
  surname?: string;
  email?: string;
  img?: string;
  phone?: string;
  address?: string;
  urlGwl?: string;
  token?: string;
  workingGroups?: any[];

  constructor(item?: Partial<User>) {

    this.id = item?.id;
    this.username = item?.username;
    this.password = item?.password;
    this.rol = item?.rol;
    this.name = item?.name;
    this.surname = item?.surname;
    this.email = item?.email;
    this.img = item?.img;
    this.phone = item?.phone;
    this.address = item?.address;
    this.urlGwl = item?.urlGwl;
    this.token = item?.token;
    this.workingGroups = item?.workingGroups;
  }










}