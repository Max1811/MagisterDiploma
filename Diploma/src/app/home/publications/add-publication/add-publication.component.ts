import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import {FormControl} from '@angular/forms';
import { PublicationService, PublicationType, ConferenceType, Conference, Digest } from '../../../services/publication.service';
import { ThrottlingExecutor } from 'src/app/shared/throttler';
import {MatDialog, MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import { AddPublicationDialog } from 'src/app/home/dialogs/add-publication/add-publication-type-dialog';
import { AddConferenceDialog } from '../../dialogs/add-conference/add-conference-dialog';
import { AddDigestDialog } from '../../dialogs/add-digest/add-digest-dialog';
import { Author } from '../../../services/publication.service';
import { AddAuthorDialog } from '../../dialogs/add-author/add-author-dialog';
import { Router } from '@angular/router';

@Component({
  selector: 'add-publication',
  templateUrl: './add-publication.component.html',
  styleUrls: ['./add-publication.component.scss']
})
export class AddPublicationComponent implements OnInit {

  public isDisplayConferenceType: boolean = false;
  public isDisplayDigest: boolean = false;
  public throttler = new ThrottlingExecutor(300);

  publicationTypeControl = new FormControl<string | PublicationType>('');
  conferenceControl = new FormControl<string | Conference>('');
  digestControl = new FormControl<string | Digest>('');
  publicationAuthorControl = new FormControl<string | Author>('');

  publicationTypes: PublicationType[] | null; 
  conferences: Conference[] | null;
  digests: Digest[] | null;
  authors: Author[] | null;

  public name: string;
  public publicationType: PublicationType;
  public conference: Conference;
  public digest: Digest;
  public publicationAuthor: Author;
  public publishingHouse: string;
  public publishingCity: string;
  public organization: string;
  public category: string;
  public link: string;
  public fromPage: number;
  public toPage: number;

  constructor(
    private publicationService: PublicationService,
    public dialog: MatDialog,
    private router: Router,
  ) {  }

  public async ngOnInit(): Promise<void> {
    this.publicationTypes = await this.publicationService.getPublicationTypes('');
    
    this.authors = await this.publicationService.getPublicationAuthors('');
    console.log(this.authors);
  }

  displayPublicationType(publicationType: PublicationType): string {
    return publicationType && publicationType.type ? publicationType.type : '';
  }

  displayConference(conference: Conference): string {
    return conference && conference.name && conference.conferenceCity ? `${conference.name}, ${conference.conferenceCity}` : '';
  }

  displayDigest(digest: Digest): string {
    return digest && digest.name && digest.type ? `${digest.name}, ${digest.type}` : '';
  }

  displayPublicationAuthor(author: Author): string {
    return author && author.name && author.lastName && author.patronymic ? `${author.name} ${author.lastName} ${author.patronymic}` : '';
  }

  public async publicationTypeChange(filter: string) {
    console.log(filter);
    this.throttler.schedule(async () => {
      this.publicationTypes = await this.publicationService.getPublicationTypes(filter);
      console.log(this.publicationTypes);
    });

    if(this.publicationType && this.publicationType.id === 1){
      this.conferences = await this.publicationService.getConferences('');
      this.isDisplayConferenceType = true;
    }
    else
      this.isDisplayConferenceType = false;

    if(this.publicationType && this.publicationType.id === 2){
      this.digests = await this.publicationService.getDigests('');
      this.isDisplayDigest = true;
    }
    else
      this.isDisplayDigest = false;
  }

  public async conferenceChange(filter: string) {
    this.throttler.schedule(async () => {
      this.conferences = await this.publicationService.getConferences(filter);
      console.log(this.conference);
    });
  }

  public async digestChange(filter: string) {
    this.throttler.schedule(async () => {
      this.digests = await this.publicationService.getDigests(filter);
    });
  }

  public async publicationAuthorChange(filter: string) {
    this.throttler.schedule(async () => {
      this.authors = await this.publicationService.getPublicationAuthors(filter);
    });
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(AddPublicationDialog, {
      data: { },
    });

    dialogRef.afterClosed().subscribe(async () => {
      this.publicationTypes = await this.publicationService.getPublicationTypes('');
    });
  }

  openConferenceDialog(): void {
    const dialogRef = this.dialog.open(AddConferenceDialog, {
      data: {  },
    });

    dialogRef.afterClosed().subscribe(async () => {
      this.conferences = await this.publicationService.getConferences('');
    });
  }

  openDigestDialog(): void {
    const dialogRef = this.dialog.open(AddDigestDialog, {
      data: {  },
    });

    dialogRef.afterClosed().subscribe(async () => {
      this.digests = await this.publicationService.getDigests('');
    });
  }

  openAddAuthorDialog(): void {
    const dialogRef = this.dialog.open(AddAuthorDialog, {
      data: {  },
    });

    dialogRef.afterClosed().subscribe(async () => {
      this.digests = await this.publicationService.getDigests('');
    });
  }

  isInvalid(){
    var returnValue: boolean = true;

    if(this.name && this.name != '' && 
       this.publicationAuthor && this.publicationAuthor.id &&
       this.publicationType && this.publicationType.id &&
       this.publishingHouse && this.publishingHouse != '' &&
       this.publishingCity && this.publishingCity != '' &&
       this.organization && this.organization != '' && 
       this.category && this.category != '' &&
       this.link && this.link != '' &&
       this.fromPage && !isNaN(this.fromPage) && this.toPage && !isNaN(this.toPage))
      returnValue = false;
    else{
      return true;
    }

    if(this.isDisplayConferenceType && (!this.conference || !this.conference.id)){
      return true;
    }

    if(this.isDisplayDigest && (!this.digest || !this.digest.id)){
      return true;
    }

    return returnValue;
  }

  public async onSubmit(): Promise<void> {
    console.log("we are here");
    await this.publicationService.addPublication({
      name: this.name,
      typeId: this.publicationType.id,
      publishingCity: this.publishingCity,
      publishingHouse: this.publishingHouse,
      pages: `${this.fromPage}-${this.toPage}`,
      organization: this.organization,
      category: this.category,
      link: this.link,
      conferenceId: this.conference ? this.conference.id : null,
      digestId: this.digest ? this.digest.id : null,
      authorId: this.publicationAuthor.id
    });

    this.router.navigate(['view-publications']);
  }
}


