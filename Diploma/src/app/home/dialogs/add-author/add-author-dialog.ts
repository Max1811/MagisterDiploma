import { Component, OnInit, Inject } from '@angular/core';
import { FormControl, NgForm, ValidatorFn } from '@angular/forms';
import {MatDialog, MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import { ConferenceType, PublicationService } from 'src/app/services/publication.service';
import { ThrottlingExecutor } from 'src/app/shared/throttler';
import { AuthorType } from 'src/app/services/publication.service';

export interface DialogData {
    publicationType: string;
  }
  
  @Component({
    selector: 'add-author-dialog',
    templateUrl: 'add-author-dialog.html',
    styleUrls: ['./../styles/styled-dialog.scss']
  })
  export class AddAuthorDialog implements OnInit {
    
    public throttler = new ThrottlingExecutor(300);

    public name: string;
    public lastName: string;
    public patronymic: string;
    public authorType: AuthorType;

    authorTypeControl = new FormControl<string | AuthorType>('');
    authorTypes: AuthorType[] | null;

    constructor(
      public dialogRef: MatDialogRef<AddAuthorDialog>,
      @Inject(MAT_DIALOG_DATA) public data: DialogData,
      private publicationService: PublicationService
    ) {}
  
    public async ngOnInit(): Promise<void> {
        this.authorTypes = await this.publicationService.getAuthorTypes('');
        //this.dialogRef.updateSize('80%', '60%');
    }

    onNoClick(): void {
      this.dialogRef.close();
    }

    isValid(){
      if(this.name && this.name !== '' &&
         this.authorType && this.authorType.id &&
         this.lastName && this.lastName !== '' &&
         this.patronymic && this.patronymic !== '')
        return false;
      return true;
    }

    public async authorTypeChange(filter: string) {
        this.throttler.schedule(async () => {
          this.authorTypes = await this.publicationService.getAuthorTypes(filter);
        });
    }
    
    displayAuthorType(authorType: AuthorType): string {
        return authorType && authorType.type ? authorType.type : '';
    }

    public async onSubmit(){
      await this.publicationService.addPublicationAuthor(this.name, this.lastName, this.patronymic, this.authorType.id);
    }
}