import { Injectable } from '@angular/core';
import { HttpClient, HttpParams} from "@angular/common/http";
import { from, Observable, of } from 'rxjs';
import { FormGroup, FormControl, Validators } from "@angular/forms";

@Injectable({
  providedIn: 'root'
})
export class ScheduleService {
  private pathAPI = "https://localhost:44340/";

  constructor(private http: HttpClient) { }

  GenerateSchedule(schedule: any) {
    console.log(schedule); 
    return this.http.post(this.pathAPI + 'api/schedule/generateschedule', schedule); 
  }
}
