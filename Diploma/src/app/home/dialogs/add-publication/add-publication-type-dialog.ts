import { Component, OnInit, Inject } from '@angular/core';
import {MatDialog, MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import { PublicationService } from 'src/app/services/publication.service';

export interface DialogData {
    publicationType: string;
  }
  
  @Component({
    selector: 'add-publication-dialog',
    templateUrl: 'add-publication-type-dialog.html',
  })
  export class AddPublicationDialog {
    public publicationType: string;

    constructor(
      public dialogRef: MatDialogRef<AddPublicationDialog>,
      @Inject(MAT_DIALOG_DATA) public data: DialogData,
      private publicationService: PublicationService
    ) {}
  
    onNoClick(): void {
      this.dialogRef.close();
    }

    public async onAddPublicationTypeClick(): Promise<void> {
      await this.publicationService.addPublicationType(this.data.publicationType);
    }
  }