import { Component, OnInit, Inject } from '@angular/core';
import { FormControl, NgForm, ValidatorFn } from '@angular/forms';
import {MatDialog, MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import { ConferenceType, PublicationService } from 'src/app/services/publication.service';
import { ThrottlingExecutor } from 'src/app/shared/throttler';

export interface DialogData {
    publicationType: string;
  }
  
  @Component({
    selector: 'add-digest-dialog',
    templateUrl: 'add-digest-dialog.html',
    styleUrls: ['./../styles/styled-dialog.scss']
  })
  export class AddDigestDialog implements OnInit {
    
    public throttler = new ThrottlingExecutor(300);

    public name: string;
    public type: string;

    constructor(
      public dialogRef: MatDialogRef<AddDigestDialog>,
      @Inject(MAT_DIALOG_DATA) public data: DialogData,
      private publicationService: PublicationService
    ) {}
  
    public async ngOnInit(): Promise<void> {
        //this.dialogRef.updateSize('60%', '40%');
    }

    onNoClick(): void {
      this.dialogRef.close();
    }

    isValid(){
      if(this.name && this.name != '' &&
         this.type && this.type)
        return false;
      return true;
    }

    public async onSubmit(){
      await this.publicationService.addDigest(this.name, this.type)
    }
}