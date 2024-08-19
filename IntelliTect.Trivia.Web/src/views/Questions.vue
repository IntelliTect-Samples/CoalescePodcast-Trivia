<template>
  <v-container>
    <h1>Random Question</h1>
    <QuestionCard
      v-if="randomQuestion !== null"
      :question="randomQuestion"
      class="mb-2"
    />

    <h1>Questions</h1>

    <v-row>
      <v-col>
        <v-text-field v-model="questions.$params.search" label="Search" />
      </v-col>
      <v-col>
        <v-select
          v-model="filterBy"
          :items="CategoryMetadata.values"
          item-title="displayName"
          item-value="value"
          multiple
          clearable
          label="Filter by Category"
          @update:model-value="filter"
        />
      </v-col>
      <v-col>
        <v-btn @click="sortByCategory">
          <v-icon class="mr-2">{{ orderByIcon }}</v-icon> Sort by Category
        </v-btn>
      </v-col>
    </v-row>

    <QuestionCard
      :question="question"
      class="mb-2"
      v-for="question in questions.$items"
      :key="question.$stableId"
    />

    <c-list-pagination :list="questions" />
  </v-container>
</template>

<script setup lang="ts">
import { Category as CategoryMetadata } from "@/metadata.g";
import {
  QuestionListViewModel,
  QuestionServiceViewModel,
} from "@/viewmodels.g";

const filterBy = ref<number[]>([]);

const questions = new QuestionListViewModel();
questions.$load();
questions.$useAutoLoad();

const questionService = new QuestionServiceViewModel();
questionService.getRandomQuestion();

const randomQuestion = computed(() => questionService.getRandomQuestion.result);

const orderByIcon = computed(() => {
  if (questions.$params.orderBy) {
    return "fa-solid fa-sort-up";
  } else if (questions.$params.orderByDescending) {
    return "fa-solid fa-sort-down";
  } else {
    return "fa-solid fa-sort";
  }
});

function filter() {
  questions.$params.filter = { category: filterBy.value.join(",") };
}

function sortByCategory() {
  // Sort by Descending
  if (questions.$params.orderBy && !questions.$params.orderByDescending) {
    questions.$params.orderBy = null;
    questions.$params.orderByDescending = "category";
  }
  // No Sort
  else if (!questions.$params.orderBy && !questions.$params.orderByDescending) {
    questions.$params.orderBy = "category";
    questions.$params.orderByDescending = null;
  }
  // Sort by Ascending
  else {
    questions.$params.orderBy = null;
    questions.$params.orderByDescending = null;
  }
}
</script>
