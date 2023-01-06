import { Component, OnInit, Inject } from '@angular/core';
import {MatDialog, MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import { PublicationService } from 'src/app/services/publication.service';

export interface DialogData {
    publicationType: string;
  }
  
  @Component({
    selector: 'add-publication-dialog',
    templateUrl: 'add-publication-type-dialog.html',
    styleUrls: ['./../styles/styled-dialog.scss']
  })
  export class AddPublicationDialog implements OnInit {
    public publicationType: string;

    constructor(
      public dialogRef: MatDialogRef<AddPublicationDialog>,
      @Inject(MAT_DIALOG_DATA) public data: DialogData,
      private publicationService: PublicationService
    ) {}
  
    ngOnInit(): void {
      //this.dialogRef.updateSize('60%', '35%');
    }

    onNoClick(): void {
      this.dialogRef.close();
    }

    isValid(){
      if(this.data.publicationType && this.data.publicationType != '')
        return false;
      return true;
    }

    public async onSubmit(): Promise<void> {
      await this.publicationService.addPublicationType(this.data.publicationType);
    }
  }