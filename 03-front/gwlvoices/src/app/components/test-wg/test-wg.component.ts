import { Component, OnInit } from '@angular/core';
import { Working_groups } from 'src/app/models/working_groups.model';
import { UserService } from 'src/app/services/user.service';
import { WgService } from 'src/app/services/wg.service';



@Component({
  selector: 'app-test-wg',
  templateUrl: './test-wg.component.html',
  styleUrls: ['./test-wg.component.css']
})
export class TestWGComponent implements OnInit {


  ArrworkingGroups: Working_groups[] = [];
  workinggroup: Working_groups[] = [];
 

  newWg: Working_groups = new Working_groups(
    { Name: "test" }
  );

  update: Working_groups = new Working_groups(
    { Id: 501, Name: "tets1" }
  )

  constructor(
    private wgservice: WgService,
    private userService: UserService) {
    // this.ArrworkingGroups = new Array();
  }

  async ngOnInit() {

    try {


<<<<<<< HEAD
      let response = await this.wgservice.getuser().subscribe(data => data.forEach(user => console.log(user)))

=======

      //  let response = await this.userService.getUserById(3);

      //  let response = await this.userService.getUserByName("Ana");

     
>>>>>>> 0f32e2dade72e94dd6fb68d35f7b059ad60512cc
      // let response = await this.wgservice.getAllWorkingGroups();
      // console.log(response)
      // response.forEach(wkname => this.ArrworkingGroups.push(wkname['name']));

      // let re = await this.wgservice.getWorkingGroupById(1);
      // this.workinggroup = Object.values(re);

      // this.wgservice.addWorkingNewWorkingGroup(this.newWg);

      // this.wgservice.updateWorkingNewWorkingGroup(this.update);

      // this.wgservice.deleteWorkingGroup(671);
    } catch (err) {
      console.log(err)














    }
  }
}
