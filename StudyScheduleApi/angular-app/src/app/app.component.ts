import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, FormArray, Validators } from '@angular/forms';
import { ScheduleService } from './services/schedule.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  scheduleForm: FormGroup;
  ScheduleList: any;
  TotalSessions: any;
  SessionsPerChapter: any;
  errorMessage: any;

   constructor(public scheduleService: ScheduleService, private formBuilder: FormBuilder) { 
   this.scheduleForm = this.formBuilder.group({
      StartingDate: ['', [Validators.required]],
      StudyWeekDays: ['', [Validators.required]],
      ChapterSessionsNo: ['', [Validators.required]]
    })
  
  }

   get f() {
    return this.scheduleForm.controls;
  }

  onSubmit() {
  if (!this.scheduleForm.valid) {
      return;
    }
    this.scheduleService.GenerateSchedule(this.scheduleForm.value)
      .subscribe((data) => {
        console.log(data);
        this.ScheduleList = data;
        this.TotalSessions = this.ScheduleList[0]['totalSessions'];
        this.SessionsPerChapter = this.ScheduleList[0]['sessionsPerChapter'];
        }, 
        error => {
          this.errorMessage = error;
          console.log(error); 
      })
  }
  cancel()
  {  
   this.scheduleForm.reset(); 
  }
}
