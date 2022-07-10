export class Userlist {

  results?: any[];
  total?: number;


  constructor(item?: Partial<Userlist>) {
    if (item != null) {
      this.results =  item.results;
      this.total = item.total;
    }else {
      this.results = new Array();
      this.total = 0;
    }
  }
}
