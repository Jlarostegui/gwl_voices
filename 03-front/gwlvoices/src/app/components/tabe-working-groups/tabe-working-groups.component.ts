import { Component, OnInit } from '@angular/core';
import { Working_groups } from 'src/app/models/working_groups.model';
import { WgService } from 'src/app/services/wg.service';

@Component({
  selector: 'app-tabe-working-groups',
  templateUrl: './tabe-working-groups.component.html',
  styleUrls: ['./tabe-working-groups.component.scss']
})
export class TabeWorkingGroupsComponent implements OnInit {

  list: Working_groups[] = [];
  displayedColumns: string[] = ['name'];




  constructor(
    private wgservices: WgService
  ) { }

  async ngOnInit() {
    try {

      let response = await this.wgservices.getAllWorkingGroups();
      response.forEach(wk => this.list.push(wk));

    } catch {

    }

  }

}
