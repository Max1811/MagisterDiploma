import { Injectable, Type } from '@angular/core';
import { ApiClient } from './api.client';

@Injectable({
    providedIn:'root'
})

export class PublicationService {
  constructor(private api: ApiClient) { }

  public getPublicationTypes(filter: string): Promise<PublicationType[] | null> {
    var url = 'publication/publication-types';

    if (filter && filter != '')
      url += `?filter=${filter}`;

    return this.api.get(url);
  }

  public getConferenceTypes(filter: string): Promise<ConferenceType[] | null> {
    var url = 'publication/conference-types';

    if (filter && filter !== '')
      url += `?filter=${filter}`;

    return this.api.get(url);
  }

  public addPublicationType(publicationType: string) {
    return this.api.post('publication/publication-type', { publicationType: publicationType });
  }

  public addConference(name: string, conferenceTypeId: number, conferenceCity: string, startDate: string, endDate: string){
    return this.api.post('publication/conference', 
      { 
        name: name, 
        conferenceTypeId: conferenceTypeId ,
        conferenceCity: conferenceCity,
        startDate: startDate,
        endDate: endDate
      });
  }

  public getConferences(filter: string): Promise<Conference[] | null>{
    var url = 'publication/conferences';

    if(filter && filter !== '')
      url += `?filter=${filter}`;

    return this.api.get(url);
  }

  public getDigests(filter: string): Promise<Digest[] | null>{
    var url = 'publication/digests';

    if(filter && filter !== '')
      url += `?filter=${filter}`;

    return this.api.get(url);
  }

  public addDigest(name: string, type: string){
    return this.api.post('publication/digest', 
      { 
        name: name, 
        type: type
      });
  }

  public getPublicationAuthors(filter: string): Promise<Author[] | null>{
    var url = 'publication/authors';

    if(filter && filter !== '')
      url += `?filter=${filter}`;

    return this.api.get(url);
  }

  public addPublicationAuthor(name: string, lastName: string, patronymic: string, authorTypeId: number){
    return this.api.post('publication/author', 
      { 
        name: name, 
        lastName: lastName,
        patronymic: patronymic,
        authorTypeId: authorTypeId
      });
  }

  public getAuthorTypes(filter: string): Promise<AuthorType[] | null>{
    var url = 'publication/author-types';

    if(filter && filter !== '')
      url += `?filter=${filter}`;

    return this.api.get(url);
  }

  public addPublication(publication: PublicationRequest) {
    return this.api.post('publication', publication);
  }

  public getPublications(filter: string): Promise<PublicationResponse[] | null>{
    var url = 'publication/publications';

    if(filter && filter !== '')
      url += `?filter=${filter}`;

    return this.api.get(url);
  }
}

export interface PublicationRequest {
  name: string,
  typeId: number,
  publishingCity: string,
  publishingHouse: string,
  pages: string,
  organization: string,
  category: string,
  link: string,
  conferenceId: number | null,
  digestId: number | null, 
  authorId: number
}

export interface PublicationResponse {
  id: number,
  name: string,
  type: PublicationType,
  publishingCity: string,
  publishingHouse: string,
  pages: string,
  organization: string,
  category: string,
  link: string,
  conference: Conference | null,
  digest: Digest | null, 
  Author: number | null
}

export interface PublicationType {
  id: number;
  type: string;
}

export interface ConferenceType {
  id: number;
  type: string;
}

export interface Conference {
  id: number;
  name: string;
  conferenceTypeId: number;
  conferenceCity: string;
  startDate: Date;
  endDate: Date;
}

export interface Digest {
  id: number,
  name: string,
  type: string
}

export interface Author {
  id: number,
  name: string,
  lastName: string,
  patronymic: string,
  authorTypeId: number
}

export interface AuthorType {
  id: number,
  type: string
}

