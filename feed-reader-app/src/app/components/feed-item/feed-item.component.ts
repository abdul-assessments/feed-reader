import { Component, OnInit, Input } from '@angular/core';
import { FeedData } from '../../interfaces/feed-data';

@Component({
  selector: 'app-feed-item',
  templateUrl: './feed-item.component.html',
  styleUrls: ['./feed-item.component.css']
})
export class FeedItemComponent implements OnInit {
  @Input()
  feedItem!: FeedData;

  constructor() { }

  ngOnInit(): void {
  }

}
