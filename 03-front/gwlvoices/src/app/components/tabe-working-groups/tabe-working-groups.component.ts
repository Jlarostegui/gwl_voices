import { Component, OnInit } from '@angular/core';
import { MatGridTileHeaderCssMatStyler } from '@angular/material/grid-list';
import { Working_groups } from 'src/app/models/working_groups.model';
import { WgService } from 'src/app/services/wg.service';

@Component({
  selector: 'app-tabe-working-groups',
  templateUrl: './tabe-working-groups.component.html',
  styleUrls: ['./tabe-working-groups.component.scss']
})
export class TabeWorkingGroupsComponent implements OnInit {

  wkgroups: Working_groups[] = new Array();

  constructor(
    private wgservices: WgService
  ) { }

  async ngOnInit() {
    try {

      this.wkgroups = await this.wgservices.getAllWorkingGroups();
      console.log(this.wkgroups);
    } catch {

    }

  }

}
