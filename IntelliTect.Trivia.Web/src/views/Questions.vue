<template>
  <v-container>
    <h1>Random Question</h1>
    <QuestionCard
      v-if="randomQuestion !== null"
      :question="randomQuestion"
      class="mb-2"
    />

    <h1>Questions</h1>
    <c-loader-status :loaders="[questions.$load]" no-initial-content>
      <v-row>
        <v-col cols="6">
          <v-text-field v-model="questions.$params.search" label="Search" />
        </v-col>
        <v-col>
          <v-select
            v-model="filterBy"
            :items="CategoryMetaData.values"
            item-title="displayName"
            item-value="value"
            multiple
            label="Filter by category"
            clearable
            @update:model-value="filter"
          />
        </v-col>
        <v-col>
          <v-btn
            @click="sortByCategory()"
            :prepend-icon="
              questions.$params.orderBy
                ? 'fa-solid fa-sort-up'
                : questions.$params.orderByDescending
                  ? 'fa-solid fa-sort-down'
                  : 'fa-solid fa-sort'
            "
          >
            Sort By Category
          </v-btn>
        </v-col>
      </v-row>

      <QuestionCard
        :question="question"
        class="mb-2"
        v-for="question in questions.$items"
        :key="question.$stableId"
      />
    </c-loader-status>
  </v-container>
</template>

<script setup lang="ts">
import { Category as CategoryMetaData } from "@/metadata.g";
import {
  QuestionListViewModel,
  QuestionServiceViewModel,
} from "@/viewmodels.g";

const filterBy = ref<number[] | null>(null);

const questions = new QuestionListViewModel();
questions.$load();
questions.$useAutoLoad();

const questionService = new QuestionServiceViewModel();
questionService.getRandomQuestion();

const randomQuestion = computed(() => questionService.getRandomQuestion.result);

function filter() {
  questions.$params.filter = { category: filterBy.value?.join(",") };
}

function sortByCategory() {
  // Sort by descending
  if (questions.$params.orderBy && !questions.$params.orderByDescending) {
    questions.$params.orderBy = null;
    questions.$params.orderByDescending = "category";
  }
  // No Sort
  else if (!questions.$params.orderBy && questions.$params.orderByDescending) {
    questions.$params.orderBy = null;
    questions.$params.orderByDescending = null;
  }
  // Sort by ascending
  else {
    questions.$params.orderBy = "category";
    questions.$params.orderByDescending = null;
  }
}
</script>
