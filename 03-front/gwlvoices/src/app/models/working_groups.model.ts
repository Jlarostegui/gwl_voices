export class Working_groups {

  id?: number;
  name?: string;


  constructor(item?: Partial<Working_groups>) {
    this.id = item?.id;
    this.name = item?.name;
  }
}