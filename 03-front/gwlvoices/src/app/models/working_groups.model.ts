export class Working_groups {

  id?: number;
  Name?: string;


  constructor(item?: Partial<Working_groups>) {
    this.id = item?.id;
    this.Name = item?.Name;
  }
}