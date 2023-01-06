import { Component, OnInit, Inject } from '@angular/core';
import { FormControl, NgForm, ValidatorFn } from '@angular/forms';
import {MatDialog, MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import { ConferenceType, PublicationService } from 'src/app/services/publication.service';
import { ThrottlingExecutor } from 'src/app/shared/throttler';

export interface DialogData {
    publicationType: string;
  }
  
  @Component({
    selector: 'add-conference-dialog',
    templateUrl: 'add-conference-dialog.html',
    styleUrls: ['./../styles/styled-dialog.scss']
  })
  export class AddConferenceDialog implements OnInit {
    
    public throttler = new ThrottlingExecutor(300);

    public conferenceName: string;
    public conferenceType: ConferenceType;
    public conferenceCity: string;
    public startDate: Date;
    public endDate: Date;

    conferenceTypeControl = new FormControl<string | ConferenceType>('');
    conferenceTypes: ConferenceType[] | null;

    constructor(
      public dialogRef: MatDialogRef<AddConferenceDialog>,
      @Inject(MAT_DIALOG_DATA) public data: DialogData,
      private publicationService: PublicationService
    ) {}
  
    public async ngOnInit(): Promise<void> {
        this.conferenceTypes = await this.publicationService.getConferenceTypes('');
        //this.dialogRef.updateSize('80%', '65%');
    } 

    onNoClick(): void {
      this.dialogRef.close();
    }

    public async conferenceTypeChange(filter: string) {
        this.throttler.schedule(async () => {
          this.conferenceTypes = await this.publicationService.getConferenceTypes(filter);
        });
    }
    
    displayConferenceType(conferenceType: ConferenceType): string {
        return conferenceType && conferenceType.type ? conferenceType.type : '';
    }

    isValid(){
      if(this.conferenceName && this.conferenceName != '' &&
         this.conferenceType && this.conferenceType.id &&
         this.conferenceCity && this.conferenceCity != '' &&
         this.startDate && this.endDate)
        return false;
      return true;
    }

    public async onSubmit(){
      await this.publicationService.addConference(this.conferenceName, this.conferenceType.id, this.conferenceCity,
         new Date(this.startDate).toISOString(), new Date(this.endDate).toISOString())
    }
}