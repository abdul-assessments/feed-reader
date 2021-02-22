import { Component, OnInit } from '@angular/core';
import { FeedResponse } from '../../interfaces/feed-response';
import { FeedService } from '../../services/feed.service';

@Component({
  selector: 'app-feed-list',
  templateUrl: './feed-list.component.html',
  styleUrls: ['./feed-list.component.css']
})
export class FeedListComponent implements OnInit {
  feed: FeedResponse;
  header: string;
  isArchive: boolean;

  constructor(public feedService: FeedService)
  {
    this.header = '';
    this.feed = { isLatest: true, feed: []} as FeedResponse;
  }

  ngOnInit(): void {
    this.getFeed('d', 'd');
  }
  getFeed(sort: string, order: string): void {
    this.feedService.getLatestFeed(sort, order)
      .subscribe(feedResponse => this.updateLatestFeed(feedResponse));
  }

  sortFeed(page: number, posts: number, sort: string, order: string): void {
    if (this.isArchive) {
      this.feedService.getArchive(page, posts, sort, order)
        .subscribe(feedResponse => this.updateArchiveFeed(feedResponse));
    }
    else {
      this.feedService.getLatestFeed(sort, order)
        .subscribe(feedResponse => this.updateLatestFeed(feedResponse));
    }
  }

  private updateLatestFeed(feedResponse: FeedResponse): void {
    this.feed.feed = feedResponse.feed;
    this.feed.isLatest = feedResponse.isLatest;
    this.feedService.loading = false;

    if (feedResponse.isLatest) {
      this.header = 'You are viewing all the latest posts from BBC Rss feed';
    }
    else {
      this.header = 'BBC Rss feed unreachable, you are viewing archived posts';
    }
  }

  private updateArchiveFeed(feedResponse: FeedResponse): void {
    this.feed.feed = feedResponse.feed;
    this.feed.isLatest = feedResponse.isLatest;
    this.feedService.loading = false;
    this.header = 'You are viewing archived posts';
  }
}
