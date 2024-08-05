<template>
  <v-card>
    <v-sheet color="secondary">
      <v-card-title>{{ question.text }}</v-card-title>
    </v-sheet>

    <v-card-text>
      <v-chip
        v-for="answer in question.answers"
        :key="answer.$stableId"
        class="mx-1"
      >
        {{ answer.text }}
      </v-chip>
    </v-card-text>
  </v-card>
</template>

<script setup lang="ts">
import { QuestionViewModel } from "@/viewmodels.g";

const props = defineProps<{
  question: QuestionViewModel;
}>();
</script>
