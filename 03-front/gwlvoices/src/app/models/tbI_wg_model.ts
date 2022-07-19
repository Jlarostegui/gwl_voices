export class tbiUserWg {


  id?: number;
  userId?: number;
  workingGrId?: number;


  constructor(item?: Partial<tbiUserWg>) {

    this.id = item?.id;
    this.userId = item?.userId;
    this.workingGrId = item?.workingGrId;
  }







}